﻿using Google.Protobuf;
using Grpc.Net.Client;
using Image.Grpc.Service;
using Microsoft.AspNetCore.Mvc;

namespace Registration.Service.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    { 


        [HttpPost]
        [Route("food")]
        public async Task<ActionResult> PostFoodImage([FromForm] CreateFoodImageDto createFoodImageDto)
        {
            var request = new PostFoodImageRequest
            {
                Restaurant = createFoodImageDto.Restaurant,
                Food = createFoodImageDto.Food
            };

            using (var stream = new MemoryStream())
            {
                await createFoodImageDto.FoodImage.CopyToAsync(stream);
                request.Image = ByteString.CopyFrom(stream.ToArray());
            }

            using var channel = GrpcChannel.ForAddress("https://localhost:5061");
            var grpcClient = new Images.ImagesClient(channel);
            var message = await grpcClient.PostFoodImageAsync(request);
            return Ok(message);
        }

    }
}