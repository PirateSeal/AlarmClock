#!/bin/bash

apt-get -y update
apt-get -y upgrade

apt-get -y install emacs-nox
apt-get -y install vim

dpkg -i /home/vagrant/vernemq-1.7.1.stretch.x86_64.deb

sed -i $'/^allow_anonymous = off/c\\allow_anonymous = on' /etc/vernemq/vernemq.conf
sed -i $'/^listener.tcp.default = 127.0.0.1:1883/c\\listener.tcp.default = 0.0.0.0:1883' /etc/vernemq/vernemq.conf

service vernemq start
