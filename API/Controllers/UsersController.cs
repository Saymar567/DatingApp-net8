using System;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("/api/[controller]")] //localhost://número/api/users
public class UsersController(DataContext context) : ControllerBase
{
    [HttpGet]
    public async  Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var users = await context.Users.ToListAsync();
        
        return users;
    }

    [HttpGet("{id:int}")] //api/users/:id
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
        var user = await context.Users.FindAsync(id);

        if(user == null) return NotFound();
        
        return user;
    }

    [HttpPost]
    public async Task<ActionResult<AppUser>> PostUser(AppUser user)
    {
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(PostUser), new{id= user.Id}, user );
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<AppUser>> DeleteUser(int id)
    {
        var user = await context.Users.FindAsync(id);

        if(user == null){
            return NotFound();
        }
        context.Users.Remove(user);
        await context.SaveChangesAsync();
        Console.WriteLine($"User {id} removed succesfully"); 
        return NoContent();
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<AppUser>> UpdateUser(int id, AppUser user)
    {
        var existingUser = await context.Users.FindAsync(id);
        if(existingUser == null){
            return NotFound();
        }
        existingUser.UserName = user.UserName;
        await context.SaveChangesAsync();
        return Ok(existingUser);
    }
}
