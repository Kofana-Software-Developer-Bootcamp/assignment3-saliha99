// See https://aka.ms/new-console-template for more information

// List created for users
List<Users> users = new List<Users>()
{
    new Users("Saliha","Apak","230","0542"),
};

// List created for products
List<Items> items = new List<Items>()
{
    new Items("1", "Cep Telefonu", "iPhone 11 128GB", "7.549,90TL"),
    new Items("2", "Kulaklık", "Airpods 3.Nesil Kulaklık", "2.528,30TL"),
    new Items("3", "Laptop", "Macbook Air 13'' M1 8gb 256gb Ssd", "14.791,53 TL"),
    new Items("4", "Akıllı Saat", "Watch Series 7 GPS", "7.420,05 TL"),
    new Items("5", "Tablet", " iPad 9. Nesil 64GB 10.2 inç Wİ-Fİ Tablet ", "5.954,30 TL")
};

List<int> itemCount = new List<int>();
List<Items> selectedItems = new List<Items>();


bool imhere = false;
bool imdone = false;

while (true)
{
    imhere = false;
    Console.WriteLine("Lütfen TC giriniz.");

    var x = Console.ReadLine();
    GetSetUser(x);
}

void GetSetUser(string id)
{
    foreach (var user in users.ToList())
    {
        if (user.Tc == id)
        {
            Console.WriteLine("Hoşgeldiniz " + user.UserName + " " + user.Surname + "\n");
            imhere = true;
            Sales();
        }
    }
    if (!imhere)
        Register();
}

void Sales()
{
    Console.WriteLine("***ÜRÜNLER***\n");

    foreach (var item in items.ToList())
        Console.WriteLine(item.Id + " " + item.Name + " " + item.Description + " " + item.Price + "\n");

    while (true)
    {
        string itemId = "";
        int count = 0;
        Console.WriteLine("Ürün seçmek için 1'e işlemi sonlandırmak için 2'ye basınız");
        switch (Console.ReadLine())

        {
            case "1":
                Console.WriteLine("\nÜrün seçmek için lütfen ürün id'si giriniz.");
                itemId = Console.ReadLine();
                if(Int16.Parse(itemId)>5 || Int16.Parse(itemId)<0 )
                {
                    Console.WriteLine("Ürün Bulunamadı!");
                    break;
                }

                Console.WriteLine("\nLütfen kaç adet istediğinizi girin:");
                count = Int32.Parse(Console.ReadLine());
                itemCount.Add(count);
                break;
            case "2":
                Console.WriteLine("\nSeçim işlemi tamamlandı!");
                Console.WriteLine("************************************************************************* \n");
                imdone = true;
                for (int i = 0; i < selectedItems.ToList().Count; i++)
                {
                    Console.WriteLine("\nSeçilen Ürün: " + selectedItems[i].Id + " " + selectedItems[i].Name + " " + selectedItems[i].Description + " " + selectedItems[i].Price + "\n Adet: " + itemCount[i] + "\n");
                }
                selectedItems.Clear();
                itemCount.Clear();
                if (selectedItems.Count <= 0)
                    Environment.Exit(1);
                break;
            default:
                Console.WriteLine("Hatalı Giriş Yaptınız. Lütfen Tekrar Deneyin.");
                break;
        }
        if (imdone)
            break;
        foreach (var item in items.ToList())
        {
            if (item.Id == itemId)
            {
                Console.WriteLine("\nSeçilen Ürün: " + item.Id + " " + item.Name + " " + item.Description + " " + item.Price + "\n");
                selectedItems.Add(new Items(item.Id, item.Name, item.Description, item.Price));
                break;
            }
        }
    }
}
void Register()
{
    Console.WriteLine("Lütfen Kayıt Olunuz...");
    Console.WriteLine("İsim:");
    var userName = Console.ReadLine();

    Console.WriteLine("Soyisim:");
    var surname = Console.ReadLine();

    Console.WriteLine("TC Kimlik No:");
    var tc = Console.ReadLine();

    Console.WriteLine("Telefon Numarası:");
    var tel = Console.ReadLine();

    Users a = new Users(userName, surname, tc, tel);

    users.Add(a);
    Console.WriteLine(users.Count);
}
public class Items
{
    public string Id;
    public string Name;
    public string Description;
    public string Price;

    public Items(string id, string name, string description, string price)
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
    }
}

public class Users
{
    public string UserName;
    public string Surname;
    public string Tc;
    public string Tel;

    public Users(string userName, string surname, string tc, string tel)
    {
        UserName = userName;
        Surname = surname;
        Tc = tc;
        Tel = tel;
    }
}