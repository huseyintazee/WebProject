using Entities.Concrete;

namespace Business.Constants;

public static class Messages
{
    public static string ProductAdded = "Ürün eklendi";
    public static string ProductNameInvalid = "Ürün ismi geçersiz";
    public static string ProductDeleted = "Ürün silindi";
    public static string ProductUpdated = "Ürün güncellendi";
    public static string MaintenanceTime = "Bakım zamanı.";
    public static string ProductsListed = "Ürünler Listelendi";
    public static string ProductCountOfCategoryError = "Bir kategoride en fazla 10 ürün olabilir.";
    public static string ProductNameAlreadyExists = "Bu isimde bir ürün zaten var.";
    public static string CategoryLimitExceded = "Kategori sayısı 15'ten fazla olduğu için ürün ekliyemezsiniz.";
}