
-- Fun for Task Table to get LanguageId
CREATE FUNCTION transfun(p_id integer) RETURNS integer AS $$
    SELECT COALESCE(TranslatorId, 0)
    FROM Translator_Competence AS tc
    WHERE tc.id = p_id;
$$ LANGUAGE SQL;

-- Fun for Task Table to get LanguageId
CREATE FUNCTION langfun(p_id integer) RETURNS integer AS $$
    SELECT COALESCE(LanguageId, 0)
    FROM Translator_Competence AS tc
    WHERE tc.id = p_id;
$$ LANGUAGE SQL;


-- Fun for Task_Review Table to get TranslatorId
CREATE OR REPLACE FUNCTION transfun1(p_id integer) 
RETURNS integer AS $$
    SELECT COALESCE (TC.TranslatorId, 0) 
    FROM Task_Review AS TR
	INNER JOIN Task AS T ON TR.TaskId = T.Id
	INNER JOIN Translator_Competence AS TC ON T.TranslatorCompetenceID = TC.Id
    WHERE TR.Id = p_id;
$$ LANGUAGE SQL;

-- Fun for Task_Review Table to get LanguageId
CREATE OR REPLACE FUNCTION langfun1(p_id integer) 
RETURNS integer AS $$
    SELECT COALESCE (TC.LanguageId, 0) 
    FROM Task_Review AS TR
	INNER JOIN Task AS T ON TR.TaskId = T.Id
	INNER JOIN Translator_Competence AS TC ON T.TranslatorCompetenceID = TC.Id
    WHERE TR.Id = p_id;
$$ LANGUAGE SQL;

--SELECT transfun1(5);
--SELECT langfun(40);
--SELECT transfun(1); // use paranthesis () around SELECT statement when inserting into VALUES
