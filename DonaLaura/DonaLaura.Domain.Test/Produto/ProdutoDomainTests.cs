﻿using DonaLaura.Domain.Exceptions;
using DonaLaura.Domain.Exceptions.Produto;
using DonaLaura.Domain.Modelo;
using DonaLauraComum.Produtos;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Test
{
    [TestFixture]
    public class ProdutoDomainTests
    {
        public Produto validProduto;
        [SetUp]
        public void Inicializar()
        {
            validProduto = ObjectMotherProduto.getValidProduto();
        }

        [Test]
        public void produto_Validacoes_ShouldBeOK()
        {
            Action validar = () => validProduto.Validate();
            validar.Should().NotThrow<ApplicationException>();
        }

        [Test]
        public void produto_ValidacoesNome_ShouldBeFail()
        {
            Produto produto = ObjectMotherProduto.getValidProduto();
            produto.Nome = "asd";
            Action validar = () => produto.Validate();
            validar.Should().Throw<NomeException>();
        }


        [Test]
        public void produto_ValidacoesData_ShouldBeFail()
        {
            Produto produto = ObjectMotherProduto.getValidProduto();
            produto.DataFabricacao = DateTime.Now;
            produto.DataValidade = DateTime.Now.AddDays(-8);
            Action validar = () => produto.Validate();
            validar.Should().Throw<DataValidadeException>();
        }

        [Test]
        public void produto_ValidacoesCusto_ShouldBeFail()
        {
            Produto produto = ObjectMotherProduto.getValidProduto();
            produto.PrecoCusto = 2.50;
            produto.PrecoVenda = 2.00;
            Action validar = () => produto.Validate();
            validar.Should().Throw<CustoException>();
        }


    }
}
