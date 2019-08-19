using System.Collections.Generic;

namespace MvcTodo.Models {
    public class TodoModel {
        public string Id { get; set; }
        public bool IsCompleted { get; set; }
        public string Title { get; set; }
    }

    public class AuthModel {
        public string Username;
        public string Password;
    }

    public class UserModel {
        public int Id;
        public string Username;
        public string Password;
        public int MembershipId;
    }

    public class MembershipModel {
        public int Id;
        public string Name;
    }

    public class PriceModel {
        public int Id;
        public int MembershipId;
        public int ProductId;
        public double Price;
    }

    public class ProductModel {
        public int Id;
        public string Name;
        public double Price;
    }

    public class CatalogModel {
        public List<ProductModel> Products;
    }
}
