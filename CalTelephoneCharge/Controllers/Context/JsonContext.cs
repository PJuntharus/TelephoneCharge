using CalTelephoneCharge.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CalTelephoneCharge.Controllers.Context
{
    public class JsonContext : DbContext
    {
        DbSet<CellPhoneChrageEntity> ObjCellPhoneChargeEntity { get; }
    }
}