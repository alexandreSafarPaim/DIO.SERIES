using System;

namespace DIO.Series
{
    public class Serie : BaseEntity
    {
        //Attributes
        private Gender Gender { get; set; }
        public string Title { get; private set; }
        private string Description { get; set; }
        private int Year { get; set; }
        public bool Excluded { get; private set; }



        //Methods
        //Constructor
        public Serie(int id, Gender gender, string title, string description, int year) : base(id)
        {
            Gender = gender;
            Title = title;
            Description = description;
            Year = year;
            Excluded = false;
        }

        public void Exclude()
        {
            Excluded = true;
        }

        public override string ToString()
        {
            string ret = "---------------------------" + Environment.NewLine;
            ret += "  Gênero: " + Gender + Environment.NewLine;
            ret += "  Título: " + Title + Environment.NewLine;
            ret += "  Descrição: " + Description + Environment.NewLine;
            ret += "  Ano de Início: " + Year + Environment.NewLine;
            ret += "  Excluido " + Excluded + Environment.NewLine;
            ret += "---------------------------";

            return ret;
        }

    }
}