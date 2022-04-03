using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime ="Sistem bakımda";
        public static string ProductsListed ="Ürünler listelendi";

        public static string ProductCountOfCategoryError = "Bir kategoride max 10 ürün";

        public static string ProductNameAlreadyExists = "Bu isimde ürün mevcut";

        public static string CategoryLimitExceded = "Katagori limiti aşıldı!!";
        public static string AuthorizationDenied = " geri bas lan ";
    }
}
