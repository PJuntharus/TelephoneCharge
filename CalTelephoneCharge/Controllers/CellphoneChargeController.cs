using CalTelephoneCharge.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CalTelephoneCharge.Controllers
{
    public class CellphoneChargeController : Controller
    {
        // GET: CellphoneCharge
        [HttpGet]
        public ActionResult CellphoneCharge()
        {

            if (!Directory.Exists(Server.MapPath("~/json")))
            {
                Directory.CreateDirectory(Server.MapPath("~/json"));
                System.IO.File.WriteAllText(Server.MapPath("~/json/cellphonecharge.json"), null);
            }

            List<CellPhoneChrageEntity> listCharge = GetJson();
            List<CellPhoneCharge> summaydata = new List<CellPhoneCharge>();
            string jasonResult = "";
            if (listCharge.Count > 0)
            {
                summaydata = SummaryCellPhoneCharge(listCharge);
                jasonResult = JsonConvert.SerializeObject(summaydata);

            }
        
            return View(summaydata);
        }

        private List<CellPhoneCharge> SummaryCellPhoneCharge(List<CellPhoneChrageEntity> listCharge)
        {
            List<CellPhoneCharge> summaryCellPhoneChrage = new List<CellPhoneCharge>();

            var listMobilePhone = listCharge.Select(list => list.Mobile_No).Distinct();

            
            foreach (var mobileNo in listMobilePhone)
            {

                CellPhoneCharge cellPhoneCharge = new CellPhoneCharge();
                var listHistory = from historylist in listCharge
                                  where historylist.Mobile_No == mobileNo
                                  select historylist;
                double summaryPayment = 0.0;

                foreach (var tellhistory in listHistory)
                {

                     CalCellCharge calCellCharge = new CalCellCharge();
                     DateTime StartTime = DateTime.Parse(tellhistory.Start_time);
                     DateTime EndTime = DateTime.Parse(tellhistory.End_time);
                     summaryPayment += calCellCharge.CalTotalCharge(tellhistory.Promotion  , StartTime , EndTime);


                }

                cellPhoneCharge.Mobile_no = mobileNo;
                cellPhoneCharge.PaymentTotal = summaryPayment;

                summaryCellPhoneChrage.Add(cellPhoneCharge);

            }

            return summaryCellPhoneChrage;
        }

        private List<CellPhoneChrageEntity> GetJson()
        {
           
            var jsonCellPhoneChargeData = new StreamReader(Server.MapPath("~/App_Data/json/cellphonecharge.json"));
            var rawJson = jsonCellPhoneChargeData.ReadToEnd();
            jsonCellPhoneChargeData.Close();

            List<CellPhoneChrageEntity> jsondata = JsonConvert.DeserializeObject<List<CellPhoneChrageEntity>>(rawJson);
            return jsondata;
        }
    }

       
}
