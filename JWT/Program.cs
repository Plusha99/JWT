using JWT.Models;
using JWT.Service;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSwaggerGen();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<IMovieService, MovieService>();

var app = builder.Build();

app.UseSwagger();


app.MapGet("/", () => "Hello World!");

app.MapPost("/create",
    (Movie movie, IMovieService service) => Create(movie, service));

app.MapGet("get",
    (int id,IMovieService service) => Get(id,service));

app.MapGet("/list",
    (IMovieService service) => List(service));

app.MapPut("/update",
    (Movie newMovie, IMovieService service) => Update(newMovie, service));

app.MapDelete("/delete",
    (int id, IMovieService service) => Delete(id, service));


IResult Create(Movie movie, IMovieService service)
{
    var result = service.Create(movie);
    return Results.Ok(result);
}


IResult Get(int id, IMovieService service)
{
    var movie = service.Get(id);
    if(movie == null)
        return Results.NotFound("Movie not found");

    return Results.Ok(movie);
}

IResult List(IMovieService service)
{
    var movies = service.List();
    return Results.Ok(movies);
}

IResult Update(Movie newMovie, IMovieService service)
{
    var updatedMovie = service.Update(newMovie);
    if(updatedMovie is null)
        return Results.NotFound("Movie not found");

    return Results.Ok(updatedMovie);
}

IResult Delete(int id, IMovieService service)
{
    var results = service.Delete(id);
    if (!results)
        return Results.BadRequest("There is no such movie. ");

    return Results.Ok(results);
}

app.UseSwaggerUI();

app.Run();
