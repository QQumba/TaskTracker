WITH RECURSIVE t AS (
    SELECT *
    FROM todo_item
    WHERE user_id = (:user_id)
    UNION
    SELECT n.*
    FROM todo_item AS n
        JOIN t
    ON n.parent_todo_item_id = t.id
)
SELECT *
FROM t;