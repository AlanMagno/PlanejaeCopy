using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Planejae.BLL.Classes;

namespace Planejae.UI.Models
{
    [Serializable]
    public class ProjetoModel
    {
        public int Id {get;set;}

        [Required]
        [Display(Name="Nome do Processo")]
        [StringLength(100, ErrorMessage="Max 100 caracteres.", MinimumLength=1)]
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        [StringLength(1024, ErrorMessage = "Max 1024 caracteres", MinimumLength = 1)]
        public string Descricao { get; set; }

        [Required]
        [Display(Name = "Data de Atualização")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Dt_Atualiz { get; set; }

        [Required]
        [Display(Name = "Usuario de Atualização")]
        public int Id_Usuario_Atuliz { get; set; }

        public ProjetoModel()
        {}

        public ProjetoModel(ProjetoBLL.ProjetoRow row)
        {
            if (row == null) return;

            this.Nome = row.Nome;
            this.Descricao = row.Desc_Projeto;
            this.Dt_Atualiz = row.Dt_Atualiz;
            //this.Id_Usuario_Atuliz = row.Id_Usuario_Atualiz;
            this.Id = row.Id_Projeto;
        }

        public ProjetoBLL.ProjetoRow ToRow()
        {
            var newRow = new ProjetoBLL().Projeto.NewProjetoRow();

            newRow.Id_Projeto = this.Id;
            newRow.Nome = this.Nome;
            newRow.Desc_Projeto = this.Descricao;
            newRow.Dt_Atualiz = this.Dt_Atualiz;
            //newRow.Id_Usuario_Atualiz = this.Id_Usuario_Atuliz;

            return newRow;
        }
    }
}