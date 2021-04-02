﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UpsApiShippingLabel.Models
{
    public class ResponseStatus
    {
        public string Code { get; set; }
        public string Description { get; set; }

    }
    public class Alert
    {
        public string Code { get; set; }
        public string Description { get; set; }

    }
    public class TransactionReference
    {
        public string CustomerContext { get; set; }
        public string TransactionIdentifier { get; set; }

    }
    public class Response
    {
        public ResponseStatus ResponseStatus { get; set; }
        public Alert Alert { get; set; }
        public TransactionReference TransactionReference { get; set; }

    }
   
    public class TransportationCharges
    {
        public string CurrencyCode { get; set; }
        public string MonetaryValue { get; set; }

    }
    public class ServiceOptionsCharges
    {
        public string CurrencyCode { get; set; }
        public string MonetaryValue { get; set; }

    }
    public class TotalCharges
    {
        public string CurrencyCode { get; set; }
        public string MonetaryValue { get; set; }

    }
    public class ShipmentCharges
    {
        public TransportationCharges TransportationCharges { get; set; }
        public ServiceOptionsCharges ServiceOptionsCharges { get; set; }
        public TotalCharges TotalCharges { get; set; }

    }
    
    public class BillingWeight
    {
        public UnitOfMeasurement UnitOfMeasurement { get; set; }
        public string Weight { get; set; }
    }
    
    public class ImageFormat
    {
        public string Code { get; set; }
        public string Description { get; set; }

    }
    public class ShippingLabel
    {
        public ImageFormat ImageFormat { get; set; }
        public string GraphicImage { get; set; }
        public string HTMLImage { get; set; }

    }
    public class PackageResults
    {
        public string TrackingNumber { get; set; }
        public ServiceOptionsCharges ServiceOptionsCharges { get; set; }
        public ShippingLabel ShippingLabel { get; set; }

    }
    public class ShipmentResults
    {
       
        public ShipmentCharges ShipmentCharges { get; set; }
        public string RatingMethod { get; set; }
        public string BillableWeightCalculationMethod { get; set; }
        public BillingWeight BillingWeight { get; set; }
        public string ShipmentIdentificationNumber { get; set; }
        public PackageResults PackageResults { get; set; }

    }
    public class ShipmentResponse
    {
        public Response Response { get; set; }
        public ShipmentResults ShipmentResults { get; set; }

    }
    public class UpsShippingResponse
    {
        public ShipmentResponse ShipmentResponse { get; set; }

    }
}