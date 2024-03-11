using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models
{
    /* CRUD CATEGORIAS
     * 
     * Aqui estão as várias propriedades da classe "Category"
     * Estas propriedades acabam por ser as colunas que queremos na Tabela
     * 
     * ---------------------   DATA ANNOTATION   -----------------------------
     * 
     * - Para definir que ID é a PK da tabela é usada "data annotation" mas
     * se for chamado Id ou algo do género CategoryId vai ser automaticamente 
     * registado como a PK, sendo assim a [Key] é desnecessária
     * 
     * - Ao adicionar [Required] cria automáticamente um not null
     * 
     * 
     */
    public class Category 
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Name { get; set; }
        public int DisplayOrder { get; set; }
    }
}
