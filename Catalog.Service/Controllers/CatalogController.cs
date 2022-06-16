using Catalog.Service.Models;
using Microsoft.AspNetCore.Mvc;
using Catalog.Service.Repository;

namespace Catalog.Service.Controllers
{
    [ApiController]
    [Route("api/v1/catalog")]
    public class CatalogController : ControllerBase
    {
        private readonly IRepository<Restaurant> _restaurantRepository;
        private readonly IRepository<Address> _addressRepository;
        private readonly IRepository<FoodCategory> _foodCategoryRepository;
        private readonly IRepository<Food> _foodRepository;

        public CatalogController(IRepository<Restaurant> restaurantRepository,
                IRepository<Address> addressRepository,
                IRepository<FoodCategory> foodCategoryRepository,
                IRepository<Food> foodRepository)
        {
            _restaurantRepository = restaurantRepository;
            _addressRepository = addressRepository;
            _foodCategoryRepository = foodCategoryRepository;
            _foodRepository = foodRepository;
        }

        [HttpGet]
        [Route("restaurants")]
        public async Task<ActionResult> Get()
        {
            var restaurants = await _restaurantRepository.GetAllAsync();
            if(restaurants.Count() == 0)
            {
                return NotFound();
            }
            return Ok(restaurants);
        }

        [HttpGet]
        [Route("restaurants/{restaurantId}/addresses")]
        public async Task<ActionResult<RestaurantWithAddressDto>> GetRestaurantAddresses(int restaurantId, string city)
        {
            var restaurant = await _restaurantRepository.GetByIdAsync(restaurantId);
            if(restaurant is null)
            {
                return NotFound($"Restaurant with id: {restaurantId} does not exists!");
            }

            var addresses = await _addressRepository.GetAllAsync(a => a.RestaurantId == restaurantId && a.City == city);
            if(addresses.Count() == 0)
            {
                return NotFound("Addresses with specified parameters do not exist!");
            }

            var restaurantWithAddressDto = new RestaurantWithAddressDto(restaurant.Name, city, addresses.ToList());
            return Ok(restaurantWithAddressDto);
        }

        [HttpGet]
        [Route("restaurants/{restaurantId}/food-categories")]
        public async Task<ActionResult<RestaurantWithFoodCategoryDto>> GetRestaurantFoodCategory(int restaurantId)
        {
            var restaurant = await _restaurantRepository.GetByIdAsync(restaurantId);
            if (restaurant is null)
            {
                return NotFound($"Restaurant with id: {restaurantId} does not exists!");
            }

            var foodCategories = await _foodCategoryRepository.GetAllAsync(c => c.RestaurantId == restaurantId);
            if(foodCategories.Count() == 0)
            {
                return NotFound("Restaurant does not have any food categories!");
            }

            var restaurantWithFoodCategories = new RestaurantWithFoodCategoryDto(restaurant.Name, foodCategories.ToList());
            return Ok(restaurantWithFoodCategories);

        }

        [HttpGet]
        [Route("restaurants/{restaurantId}/food-categories/{categoryId}/foods")]
        public async Task<ActionResult<FoodsViewDto>> GetFoods(int restaurantId, int categoryId)
        {
            var restaurant = await _restaurantRepository.GetByIdAsync(restaurantId);
            if (restaurant is null)
            {
                return NotFound($"Restaurant with id: {restaurantId} does not exists!");
            }

            var foodCategory = await _foodCategoryRepository.GetByIdAsync(categoryId);
            if(foodCategory is null)
            {
                return NotFound($"Food category with id: {categoryId} does not exists!");
            }

            var foods = await _foodRepository.GetAllAsync(f => f.RestaurantId == restaurantId && f.CategoryId == categoryId);
            if(foods.Count() == 0)
            {
                return NotFound($"Category '{foodCategory.CategoryName}' does not have any foods!");
            }

            var foodViewDto = new FoodsViewDto(restaurant.Name, foodCategory.CategoryName, foods.ToList());
            return Ok(foodViewDto);
        }

    }
}