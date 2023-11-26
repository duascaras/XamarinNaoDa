using SQLite;
using System;

namespace XamarinNaoDa.Models
{
    public class Postagem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public DateTime DataPostagem { get; set; }
        public string Comentario { get; set; }
        public string Foto { get; set; }
    }
}