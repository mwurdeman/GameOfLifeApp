SELECT *
FROM Location

SELECT *
FROM Offer

SELECT *
FROM Store

SELECT 
	L.LocationID
	, O.OfferID
	, O.Name
	, O.Details
	, LO.DaysOfWeek
FROM Location L
	JOIN LocationOffer LO ON L.LocationID = LO.LocationID
	JOIN Offer O ON LO.OfferID = O.OfferID

SELECT 
	StoreID,
	Name
FROM Store

SELECT 
	OfferID
	, Name
	, Details
FROM Offer