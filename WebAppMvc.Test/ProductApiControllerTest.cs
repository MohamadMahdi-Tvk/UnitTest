using Microsoft.AspNetCore.Mvc;
using Moq;
using UnitTest.MVC.Controllers;
using UnitTest.MVC.Models.Entities;
using UnitTest.MVC.Models.MockData;
using UnitTest.MVC.Services;

namespace WebAppMvc.Test;

public class ProductApiControllerTest
{
    MoqData _moqdata;
    public ProductApiControllerTest()
    {
        _moqdata = new MoqData();
    }

    [Fact]
    public void GetTest()
    {
        //Arrange

        var moq = new Mock<IProductService>();
        moq.Setup(p => p.GetAll()).Returns(_moqdata.GetAll());
        ProductApiController apiController = new ProductApiController(moq.Object);

        //Act

        var result = apiController.Get();

        //Assert
        Assert.IsType<OkObjectResult>(result);
        var list = result as OkObjectResult;
        Assert.IsType<List<Product>>(list.Value);
    }

    [Theory]
    [InlineData(1, -1)]
    public void GetByIdTest(int ValidId, int inValidId)
    {
        //Arrange
        var moq = new Mock<IProductService>();
        moq.Setup(p => p.GetById(ValidId)).Returns(_moqdata.GetAll().FirstOrDefault(p => p.Id == ValidId));
        ProductApiController apiController = new ProductApiController(moq.Object);

        //Act

        var result = apiController.Get(ValidId);

        //Assert
        Assert.IsType<OkObjectResult>(result);
        var product = result as OkObjectResult;
        Assert.IsType<Product>(product.Value);

        //--------------------------


        //Arrange
        moq.Setup(p => p.GetById(inValidId)).Returns(_moqdata.GetAll().FirstOrDefault(p => p.Id == inValidId));

        //Act

        var invalidResult = apiController.Get(inValidId);

        //Assert
        Assert.IsType<NotFoundResult>(invalidResult);

    }

    [Fact]
    public void Post_Test()
    {
        //Areange
        var moq = new Mock<IProductService>();

        ProductApiController controller = new ProductApiController(moq.Object);

        Product product = new Product()
        {
            Id = 1,
            Description = "cccc",
            Name = "Samsung",
            Price = 4500
        };


        //Act

        var result = controller.Post(product);

        //Assert

        Assert.IsType<CreatedAtActionResult>(result);


    }


    [Theory]
    [InlineData(1, -1)]
    public void Delete_Test(int ValidId, int inValidId)
    {
        //Arrange
        var moq = new Mock<IProductService>();

        moq.Setup(p => p.Remove(ValidId));
        moq.Setup(p => p.GetById(ValidId)).Returns(_moqdata.GetAll().FirstOrDefault(p => p.Id == ValidId));

        ProductApiController apiController = new ProductApiController(moq.Object);

        //Act
        var result = apiController.Delete(ValidId);
        var invalidResult = apiController.Delete(inValidId);
        //Assert

        Assert.IsType<OkObjectResult>(result);

        Assert.IsType<NotFoundResult>(invalidResult);
    }


}
