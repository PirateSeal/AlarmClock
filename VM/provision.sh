
#!/bin/bash


apt-get -y update
apt-get -y upgrade

apt-get -y install postgresql 

su - postgres -c "psql < /tmp/createSqlUsers.sql"


apt-get -y install emacs-nox
apt-get -y install vim

dpkg -i /home/vagrant/vernemq-1.8.0.stretch.x86_64.deb

sed -i $'/^allow_anonymous = on/c\\allow_anonymous = off' /etc/vernemq/vernemq.conf
sed -i $'/^listener.tcp.default = 127.0.0.1:1883/c\\listener.tcp.default = 0.0.0.0:1883' /etc/vernemq/vernemq.conf



## verneMQ database conf
 
sed -i $'/^vmq_diversity.auth_postgres.enabled = off/c\\vmq_diversity.auth_postgres.enabled = on' /etc/vernemq/vernemq.conf
sed -i $'/^## vmq_diversity.postgres.database = vernemq_db/c\\vmq_diversity.postgres.database = vernemq_db' /etc/vernemq/vernemq.conf


sed -i $'/^plugins.vmq_diversity = off/c\\plugins.vmq_diversity = on' /etc/vernemq/vernemq.conf
sed -i $'/^plugins.vmq_passwd = on/c\\plugins.vmq_passwd = off' /etc/vernemq/vernemq.conf
sed -i $'/^plugins.vmq_acl = on/c\\plugins.vmq_acl = off' /etc/vernemq/vernemq.conf

sed -i $'/^## vmq_diversity.postgres.password = password/c\\vmq_diversity.postgres.password = vernemq' /etc/vernemq/vernemq.conf
sed -i $'/^## vmq_diversity.postgres.port = 5432/c\\vmq_diversity.postgres.port = 5432' /etc/vernemq/vernemq.conf
sed -i $'/^## vmq_diversity.postgres.host = localhost/c\\vmq_diversity.postgres.host = 127.0.0.1' /etc/vernemq/vernemq.conf
sed -i $'/^## vmq_diversity.postgres.user = root/c\\vmq_diversity.postgres.user = vernemq' /etc/vernemq/vernemq.conf

##echo "vmq_diversity.postgres.password_hash_method = crypt" >> /etc/vernemq/vernemq.conf

## postgres conf 

sed -i $'/^## vmq_diversity.postgres.user = root/c\\host all all 0.0.0.0/0  password' /etc/postgresql/9.6/main/pg_hba.conf
sed -i $'/# IPv4 local connections:/a\host all all 0.0.0.0/0  password' /etc/postgresql/9.6/main/pg_hba.conf
sed -i $'/# listen_addresses = \'localhost\'/c\\listen_addresses = \'*\'' /etc/postgresql/9.6/main/postgresql.conf 


systemctl restart postgresql

service vernemq start



