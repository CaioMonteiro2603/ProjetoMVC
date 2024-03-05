namespace ProjetoMVC.Models
{
    public class ContactModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Telephone { get; set; }

        public bool Active { get; set; }

        public ContactModel()
        {
            
        }

        public ContactModel(int id, string name, string telephone, bool active)
        {
            Id = id;
            Name = name;
            Telephone = telephone;
            Active = active;
        }
    }
}
