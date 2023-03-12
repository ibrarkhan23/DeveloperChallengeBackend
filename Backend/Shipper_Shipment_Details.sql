
CREATE or ALTER PROCEDURE [dbo].[Shipper_Shipment_Details] --[dbo].[Shipper_Shipment_Details] 1
	@shipperId INT
AS

	BEGIN

		select sp.shipment_id as shipmentId ,sh.shipper_name as shipperName,cr.carrier_name as carrierName,sp.shipment_description as shipmentDescription,sp.shipment_weight as shipmentWeight,sr.shipment_rate_description as shipmentRateDescription
		from dbo.SHIPMENT sp 
		left join dbo.SHIPPER sh on sp.shipper_id = sh.shipper_id
		left join dbo.CARRIER cr on cr.carrier_id = sp.carrier_id
		left join dbo.SHIPMENT_RATE sr on sr.shipment_rate_id = sp.shipment_rate_id
		where sp.shipper_id = @shipperId order by sh.shipper_name ASC
	END;

GO



--DDL Commands For StoredProcdure 
-- Create PROCEDURE Name 
-- Alter PROCEDURE Existing Name 
-- Drop Procdure Exisiting Name 
