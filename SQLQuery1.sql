CREATE TABLE MathExpressionHistory
(
    id                INT          NOT NULL     IDENTITY,
    expression        VARCHAR(100) NOT NULL,
    resultExpression  NUMERIC(38,2), 

    PRIMARY KEY (id)
)