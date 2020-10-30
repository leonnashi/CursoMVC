using CursoAPI.Controllers;
using CursoMVC.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace CursoMVC_Testes
{
    public class CategoriasControllerTest
    {
        private readonly Mock<DbSet<Categoria>> _mockSet;
        private readonly Mock<Context> _mockContext;
        private readonly Categoria _categoria;

        public CategoriasControllerTest()
        {
            _mockSet = new Mock<DbSet<Categoria>>();
            _mockContext = new Mock<Context>();
            _categoria = new Categoria { Id = 1, Descricao = "Teste Categoria" };

            _mockContext.Setup(m => m.categorias).Returns(_mockSet.Object);
            _mockContext.Setup(m => m.categorias.FindAsync(1)).ReturnsAsync(_categoria);
        }

        [Fact]
        public async Task GET_Categoria()
        {
            var service = new CategoriasController(_mockContext.Object);

            await service.GetCategoria(1);

            _mockSet.Verify(m => m.FindAsync(1),
                            Times.Once());

        }
    }
}

