using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EcX.Dominio.Servico;
using MSTestExtensions;
using Moq;
using EcX.Dominio.Repositorio;
using FizzWare.NBuilder;
using EcX.Dominio.Entidade;

namespace Ecx.Dominio.Teste
{
    [TestClass]
    public class UsuarioServicoTest : BaseTest
    {
        UsuarioServicoDominio usuario = null;
        private Mock<IRepositorioUsuario> _repositorio;

        [TestInitialize]
        public void InicializarTestes()
        {
            _repositorio = new Mock<IRepositorioUsuario>();

            usuario = new UsuarioServicoDominio(_repositorio.Object);
        }
        [TestMethod]
        public void Criar_Conta_Sucesso()
        {
            var objetoInserir = Builder<UsuarioEntidade>.CreateNew().Build();

            _repositorio.Setup(_ => _.Inserir(objetoInserir));

            usuario.Inserir(objetoInserir);

            _repositorio.VerifyAll();
        }

        [TestMethod]
        public void Autenticar_Conta_Sucesso()
        {
            var objetolista = Builder<UsuarioEntidade>.CreateListOfSize(10).Build();

            _repositorio.Setup(_ => _.Listar()).Returns(() => { return objetolista; });

            usuario.Autenticar(objetolista[0]);

            _repositorio.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Autenticar_Conta_Erro()
        {
            var objetolista = Builder<UsuarioEntidade>.CreateListOfSize(10).Build();

            _repositorio.Setup(_ => _.Listar()).Returns(() => { return objetolista; });

            usuario.Autenticar(new UsuarioEntidade());

            _repositorio.VerifyAll();
        }
    }
}
