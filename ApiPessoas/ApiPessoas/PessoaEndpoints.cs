using Microsoft.EntityFrameworkCore;
using ApiPessoas.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace ApiPessoas;

public static class PessoaEndpoints
{
    public static void MapPessoaModelEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/PessoaModel").WithTags(nameof(PessoaModel));

        group.MapGet("/", async (ApiPessoasContext db) =>
        {
            return await db.PessoaModel.ToListAsync();
        })
        .WithName("GetAllPessoaModels")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<PessoaModel>, NotFound>> (int id, ApiPessoasContext db) =>
        {
            return await db.PessoaModel.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is PessoaModel model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetPessoaModelById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, PessoaModel pessoaModel, ApiPessoasContext db) =>
        {
            var affected = await db.PessoaModel
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, pessoaModel.Id)
                    .SetProperty(m => m.Nome, pessoaModel.Nome)
                    .SetProperty(m => m.Sobrenome, pessoaModel.Sobrenome)
                    .SetProperty(m => m.DataNascimento, pessoaModel.DataNascimento)
                    .SetProperty(m => m.CPF, pessoaModel.CPF)
                    .SetProperty(m => m.RG, pessoaModel.RG)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdatePessoaModel")
        .WithOpenApi();

        group.MapPost("/", async (PessoaModel pessoaModel, ApiPessoasContext db) =>
        {
            db.PessoaModel.Add(pessoaModel);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/PessoaModel/{pessoaModel.Id}",pessoaModel);
        })
        .WithName("CreatePessoaModel")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, ApiPessoasContext db) =>
        {
            var affected = await db.PessoaModel
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeletePessoaModel")
        .WithOpenApi();
    }
}
