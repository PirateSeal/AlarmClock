/*
 * File: Proc_VerneMq_ACL.sql                                                  *
 * Project: VM                                                                 *
 * File Created: Monday,1st June 2019 01:46:01 pm                              *
 * Author: Le Phoque Pirate                                                    *
 * --------------------                                                        *
 * Last Modified: Monday, 17th June 2019 1:46:02 pm                            *
 * Modified By: Le Phoque Pirate (tcousin@intechinfo.fr)                       *
 */

CREATE OR replace PROCEDURE AclCreation
(string, string, int)
LANGUAGE plpgsql
AS $$
BEGIN

    WITH
        temp
        AS
        (
            SELECT
                ''
        
        ::text AS [mountpoint],
        $1::text AS [client_id],
        $2:: text AS [username],
        $3::text AS [password],
        gen_salt
    ('bf')::text AS [salt],
        '[{"pattern": "a/b/c"}, {"pattern": "c/b/#"}]'::json AS publish_acl,
        '[{"pattern": "a/b/c"}, {"pattern": "c/b/#"}]'::json AS subscribe_acl
    )

    INSERT INTO vmq_auth_acl
        (
        [mountpoint], [client_id], [username], [password], [publish_acl]
        )

    SELECT
        x.mountpoint,
        x.client_id,
        x.username,
        crypt(x.[password], x.salt),
        publish_acl,
        subscribe_acl
    FROM x;

END;
