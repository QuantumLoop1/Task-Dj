CREATE VIEW vw_DJTracks AS
SELECT
    dj.Id AS DJId,
    dj.Name AS DJName,
    dj.Genre,
    dj.Rating,
    t.Id AS TrackId,
    t.Title AS TrackTitle,
    t.Duration
FROM DJ dj
         INNER JOIN Track t ON dj.Id = t.DJId

SELECT * FROM vw_DJTracks