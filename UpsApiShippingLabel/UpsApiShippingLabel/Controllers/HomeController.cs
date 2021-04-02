using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;
using UpsApiShippingLabel.Models;

namespace UpsApiShippingLabel.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [HttpPost]
        public JsonResult GenerateLabel(UpsShippingRequest upsShippingRequest)
        {
            if(upsShippingRequest.ShipmentRequest.Shipment.ShipmentRatingOptions.NegotiatedRatesIndicator == null) {
                upsShippingRequest.ShipmentRequest.Shipment.ShipmentRatingOptions.NegotiatedRatesIndicator = string.Empty; 
            }
            var jsonResponse = string.Empty;
            //var upsShippingRequest = BuildShippingRequest();
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("AccessLicenseNumber", "4D826342A87374B5");
            client.DefaultRequestHeaders.Add("Password", "upsTestApi!");
            //client.DefaultRequestHeaders.Add("Content-Type", "application/json");
            client.DefaultRequestHeaders.Add("transId", "1");
            client.DefaultRequestHeaders.Add("transactionSrc", "gg");
            client.DefaultRequestHeaders.Add("Username", "basel81");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            var jsonRequest = JsonConvert.SerializeObject(upsShippingRequest);
            HttpContent httpContent = new StringContent(jsonRequest);
            var response = client.PostAsync("https://wwwcie.ups.com/ship/v1/shipments", httpContent);
            if (response.Result.IsSuccessStatusCode)
            {
                jsonResponse = response.Result.Content.ReadAsStringAsync().Result;
                //var upsShippingResponse = JsonConvert.DeserializeObject<UpsShippingResponse>(jsonResponse);
            };
            return Json(jsonResponse);
        }

        private UpsShippingRequest BuildShippingRequest()
        {
            var upsShippingRequest = new UpsShippingRequest
            {
                ShipmentRequest = new ShipmentRequest()
            };
            upsShippingRequest.ShipmentRequest.Shipment = new Shipment
            {
                Service = new Service
                {
                    Code = "03"
                },
                Package = new List<Package>{
                            new Package
                            {
                                Packaging = new Packaging
                                {
                                    Code = "02"
                                },
                                PackageWeight = new PackageWeight
                                {
                                    UnitOfMeasurement = new UnitOfMeasurement
                                    {
                                        Code = "LBS",
                                    },
                                    Weight = "2"
                                },
                                PackageServiceOptions = ""
                            }
                        },
                ItemizedChargesRequestedIndicator = "",
                RatingMethodRequestedIndicator = "",
                TaxInformationIndicator = "",
                ShipmentRatingOptions = new ShipmentRatingOptions
                {
                    NegotiatedRatesIndicator = ""
                },
                Description = "1206 PTR",
                PaymentInformation = new PaymentInformation
                {
                    ShipmentCharge = new ShipmentCharge
                    {
                        Type = "01",
                        BillShipper = new BillShipper
                        {
                            AccountNumber = "V3478F"
                        }
                    }
                }
            };
            upsShippingRequest.ShipmentRequest.Shipment.Shipper = new Shipper
            {
                Name = "ShipperName",
                AttentionName = "AttentionName",
                Phone = new Phone
                {
                    Number = "6354836432"
                },
                ShipperNumber = "V3478F",
                Address = new Address
                {
                    AddressLine = "AddressLine",
                    City = "Dublin",
                    StateProvinceCode = "OH",
                    CountryCode = "US",
                    PostalCode = "43017"
                }
            };
            upsShippingRequest.ShipmentRequest.Shipment.ShipFrom = new ShipFrom
            {
                Name = "ShipFromName",
                AttentionName = "AttentionName",
                Phone = new Phone
                {
                    Number = "6354836432"
                },
                FaxNumber = "4564564644",
                TaxIdentificationNumber = "456999",
                Address = new Address
                {
                    AddressLine = "AddressLine",
                    City = "Dublin",
                    StateProvinceCode = "OH",
                    CountryCode = "US",
                    PostalCode = "43017"
                }
            };
            upsShippingRequest.ShipmentRequest.Shipment.ShipTo = new ShipTo
            {
                Name = "ShipToName",
                AttentionName = "AttentionName",
                Phone = new Phone
                {
                    Number = "6355555532"
                },
                FaxNumber = "4564564644",
                TaxIdentificationNumber = "456990",
                Address = new Address
                {
                    AddressLine = "AddressLine",
                    City = "Dublin",
                    StateProvinceCode = "OH",
                    CountryCode = "US",
                    PostalCode = "43016"
                }
            };

            upsShippingRequest.ShipmentRequest.LabelSpecification = new LabelSpecification
            {
                LabelImageFormat = new LabelImageFormat
                {
                    Code = "GIF"
                }
            };
            return upsShippingRequest;
        }

    }
}
