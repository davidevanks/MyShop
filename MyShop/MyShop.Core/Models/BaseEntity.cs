using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Models
{
    //Poniendo la clase de manera abstracta, indicamos que no se puede instanciar, para usarla otra clase
    //la debe heredar o implementar. esta se implementa en InMemoryRepository
    public abstract class BaseEntity
    {

        public String Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }

        public BaseEntity()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedAt = DateTime.Now;
        }

    }
}
