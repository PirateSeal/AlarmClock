
CREATE DATABASE vernemq_db;
CREATE ROLE vernemq WITH PASSWORD 'vernemq';
ALTER ROLE vernemq WITH LOGIN;
ALTER ROLE vernemq WITH SUPERUSER;


\c vernemq_db

CREATE EXTENSION pgcrypto;

CREATE TABLE vmq_auth_acl
 (
   mountpoint character varying(10) NOT NULL,
   client_id character varying(128) NOT NULL,
   username character varying(128) NOT NULL,
   password character varying(128),
   publish_acl json,
   subscribe_acl json,
   CONSTRAINT vmq_auth_acl_primary_key PRIMARY KEY (mountpoint, client_id, username)
 );

