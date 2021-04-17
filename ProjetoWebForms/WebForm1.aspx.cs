﻿using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoWebForms
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            LoadGrid();
        }

        protected void BtnSalvar_Click(object sender, EventArgs e)
        {
            Ferramentas ferramenta = getData();
            var db = new FerramentaDB();

            if (db.Insert(ferramenta))
            {
                LblMsg.Text = "Registro inserido!";
                LoadGrid();
            }
            else
                LblMsg.Text = "Erro ao inserir registro";
        }

        private Ferramentas getData()
        {
            return new Ferramentas()
            {
                Descricao = TxtDescricao.Text,
                Tipo = TxtTipo.Text,
                Marca = TxtMarca.Text,
                Preco = TxtPreco.Text
            };
        }

        private void LoadGrid()
        {
            GVFerramenta.DataSource = new FerramentaDB().GetAll();
            GVFerramenta.DataBind();
        }
    }
}