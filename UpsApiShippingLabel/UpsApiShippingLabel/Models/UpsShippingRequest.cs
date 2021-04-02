using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UpsApiShippingLabel.Models
{
    public class Phone
    {
        public string Number { get; set; }

    }
    public class Address
    {
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string StateProvinceCode { get; set; }
        public string PostalCode { get; set; }
        public string CountryCode { get; set; }

    }
    public class Shipper
    {
        public string Name { get; set; }
        public string AttentionName { get; set; }
        public Phone Phone { get; set; }
        public string ShipperNumber { get; set; }
        public Address Address { get; set; }

    }
   
    public class ShipTo
    {
        public string Name { get; set; }
        public string AttentionName { get; set; }
        public Phone Phone { get; set; }
        public string FaxNumber { get; set; }
        public string TaxIdentificationNumber { get; set; }
        public Address Address { get; set; }

    }
  
    public class ShipFrom
    {
        public string Name { get; set; }
        public string AttentionName { get; set; }
        public Phone Phone { get; set; }
        public string FaxNumber { get; set; }
        public string TaxIdentificationNumber { get; set; }
        public Address Address { get; set; }

    }
    public class BillShipper
    {
        public string AccountNumber { get; set; }

    }
    public class ShipmentCharge
    {
        public string Type { get; set; }
        public BillShipper BillShipper { get; set; }

    }
    public class PaymentInformation
    {
        public ShipmentCharge ShipmentCharge { get; set; }

    }
    public class Service
    {
        public string Code { get; set; }

    }
    public class Packaging
    {
        public string Code { get; set; }

    }
    public class UnitOfMeasurement
    {
        public string Code { get; set; }

    }
    public class PackageWeight
    {
        public UnitOfMeasurement UnitOfMeasurement { get; set; }
        public string Weight { get; set; }

    }
    public class Package
    {
        public Packaging Packaging { get; set; }
        public PackageWeight PackageWeight { get; set; }
        public string PackageServiceOptions { get; set; }

    }
    public class ShipmentRatingOptions
    {
        public string NegotiatedRatesIndicator { get; set; }

    }
    public class Shipment
    {
        public string Description { get; set; }
        public Shipper Shipper { get; set; }
        public ShipTo ShipTo { get; set; }
        public ShipFrom ShipFrom { get; set; }
        public PaymentInformation PaymentInformation { get; set; }
        public Service Service { get; set; }
        public IList<Package> Package { get; set; }
        public string ItemizedChargesRequestedIndicator { get; set; }
        public string RatingMethodRequestedIndicator { get; set; }
        public string TaxInformationIndicator { get; set; }
        public ShipmentRatingOptions ShipmentRatingOptions { get; set; }

    }
    public class LabelImageFormat
    {
        public string Code { get; set; }

    }
    public class LabelSpecification
    {
        public LabelImageFormat LabelImageFormat { get; set; }

    }
    public class ShipmentRequest
    {
        public Shipment Shipment { get; set; }
        public LabelSpecification LabelSpecification { get; set; }

    }
    public class UpsShippingRequest
    {
        public ShipmentRequest ShipmentRequest { get; set; }

    }
}