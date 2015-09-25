SELECT *
FROM Location

SELECT *
FROM Offer

SELECT *
FROM Store

SELECT 
	S.Name
	, L.Name
	, L.LocationID
	, O.OfferID
	, O.Name
	, O.Details
	, LO.DaysOfWeek
FROM Location L
	JOIN LocationOffer LO ON L.LocationID = LO.LocationID
	JOIN Offer O ON LO.OfferID = O.OfferID
	Join Store S on L.StoreID = S.StoreID

SELECT 
	StoreID,
	Name
FROM Store

SELECT 
	OfferID
	, Name
	, Details
FROM Offer

SELECT S.StoreID
	, L.LocationID
	, O.OfferID 
	, S.Name as StoreName
	, L.Name as LocationName
	, L.Address1
	, L.Address2
	, L.City
	, L.State
	, L.ZipCode
	, O.Details
	, LO.DaysOfWeek
FROM Store S
	JOIN Location L ON S.StoreID = L.StoreID
	JOIN LocationOffer LO ON L.LocationID = LO.LocationID
	JOIN Offer O ON LO.OfferID = O.OfferID
WHERE LO.DaysOfWeek LIKE '%Mo%'

SELECT *
FROM Store
WHERE StoreID = 2

SELECT *
FROM Location