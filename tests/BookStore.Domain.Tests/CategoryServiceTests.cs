using BookStore.Domain.Interfaces;
using BookStore.Domain.Models;
using BookStore.Domain.Services;
using Moq;

namespace BookStore.Domain.Tests;

public class CategoryServiceTests
{
    private readonly Mock<ICategoryRepository> _categoryRepositoryMock;
    private readonly Mock<IBookService> _bookService;
    private readonly CategoryService _categoryService;

    public CategoryServiceTests()
    {
        _categoryRepositoryMock = new Mock<ICategoryRepository>();
        _bookService = new Mock<IBookService>();
        _categoryService = new CategoryService(
            _categoryRepositoryMock.Object,
            _bookService.Object);
    }

    [Fact]
    public async void GetAll_ShouldReturnAListOfCategories_WhenCategoriesExist()
    {
        var categories = CreateCategoryList();

        _categoryRepositoryMock.Setup(c => c.GetAll())
            .ReturnsAsync(categories);

        var result = await _categoryService.GetAll();

        Assert.NotNull(result);
        Assert.IsType<List<Category>>(result);
    }

    [Fact]
    public async void GetAll_ShouldReturnNull_WhenCategoriesDoesNotExist()
    {
        _categoryRepositoryMock.Setup(c => c.GetAll())
            .ReturnsAsync((List<Category>)null);

        var result = await _categoryService.GetAll();

        Assert.Null(result);
    }

    [Fact]
    public async void GetAll_ShouldCallGetAllFromRepository_OnlyOnce()
    {
        _categoryRepositoryMock.Setup(c => c.GetAll())
            .ReturnsAsync((List<Category>)null);

        await _categoryService.GetAll();
        
        _categoryRepositoryMock.Verify(mock => mock.GetAll(), Times.Once);
    }

    [Fact]
    public async void GetById_ShouldReturnCategory_WhenCategoryExists()
    {
        var category = CreateCategory();

        _categoryRepositoryMock.Setup(c => c.GetById(category.Id))
            .ReturnsAsync(category);

        var result = await _categoryService.GetById(category.Id);

        Assert.NotNull(result);
        Assert.IsType<Category>(result);
        Assert.Equal(result.Id, category.Id);
    }

    [Fact]
    public async void GetById_ShouldReturnNull_WhenCategoryDoesNotExist()
    {
        _categoryRepositoryMock.Setup(c => c.GetById(1))
            .ReturnsAsync((Category)null);
        var result = await _categoryService.GetById(1);

        Assert.Null(result);
    }

    [Fact]
    public async void GetById_ShouldCallGetByIdFromRepository_OnlyOnce()
    {
        _categoryRepositoryMock.Setup(c => c.GetById(1))
            .ReturnsAsync((Category)null);

        await _categoryService.GetById(1);

        _categoryRepositoryMock.Verify(mock => mock.GetById(1), Times.Once);
    }

    [Fact]
    public async void Add_ShouldAddCategory_WhenCategoryNameDoesNotExists()
    {
        var category = CreateCategory();

        _categoryRepositoryMock.Setup(c => c.Search(
                c => c.Name == category.Name))
            .ReturnsAsync(new List<Category>());

        _categoryRepositoryMock.Setup(c => c.Add(category));

        var result = await _categoryService.Add(category);

        Assert.NotNull(result);
        Assert.IsType<Category>(result);
    }

    private Category CreateCategory()
    {
        return new Category()
        {
            Id = 1,
            Name = "Test Category 1"
        };
    }

    private List<Category> CreateCategoryList()
    {
        return new List<Category>()
        {
            new Category()
            {
                Id = 1,
                Name = "Test Category 1"
            },
            new Category()
            {
                Id = 2,
                Name = "Test Category 2"
            },
            new Category()
            {
                Id = 3,
                Name = "Test Category 3"
            }
        };
    }
}