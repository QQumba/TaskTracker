WITH RECURSIVE t AS (
    SELECT *
    FROM todo_item
    UNION
    SELECT n.*
    FROM todo_item AS n
        JOIN t
    ON n.parent_todo_item_id = t.id
)
SELECT *
FROM t;