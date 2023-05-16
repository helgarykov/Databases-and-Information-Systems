
/*  Lecture slides. 16.05 */
/* Extracting date from tables */

Users(uid, name, joineddate)
Posts(pid, uid, date, text)
Mentions(pid, uid)

SELECT DISTINCT U.name
FROM Users U, Posts P
where U.uid = P.uid AND U.joindate >= "1/1/2020" AND P.date < "1/1/2022"


SELECT P.text
FROM Users U1, Posts P, Mentions M, Users U2
WHERE P.pid = M.pid AND U1.uid = P.uid AND U1.name =  "Dmitriy" 
      AND U2.uid = M.uid AND U2.name = "MC"

SELECT S.sid
FROM Sailors S, Boats B, Reserves R 
WHERE S.sid=R.sid AND R.bid=B.bid 
    AND (B.color = 'red' OR B.color='green')


/* 

UION (set union) vs UNION ALL (bag union)
INTERSECT vs EXCEPT (except is set difference: red boat but not green boat)

*/

/* Adding & deleting tuples */
/* NULL: assumes IDENTITY column, generate for me primary keys (will be random) */

INSERT INTO Students(sid, name, login, age, gpa)
SELECT NULL, name, login, age, 0.0
FROM Other_Studets
WHERE school = 'KU'

DELETE FROM TABLE
Where Condiiton

UPDATE TABLE
SET A1 = EXPR1(old), A2 = EXPR2, An= EXPRn
where condition

/* Cross Join = Cartesian Product */

SELECT S.*, E.*
FROM MovieStar S
    JOIN MovieExec E
    On S.name = E.name


FROM MovieStar CROSS JOIN MovieExec

/* Equijoins */

SELECT *
FROM MovieStar S
    INNER JOIN MovieExec E
    USING (name)

/* Natural join */

SELECT *
