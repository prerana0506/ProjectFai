using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectFai.Models;

namespace ProjectFai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly RoomDbContext context;
        public RoomController(RoomDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Room>>> AllRooms()
        {
            return await context.Rooms.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> FindRoom(int id)
        {
            return await context.Rooms.FindAsync(id) ?? throw new Exception("Example not found");
        }

        [HttpPost]
        public async Task<ActionResult<Room>> AddEmployee(Room room)
        {
            context.Rooms.Add(room);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(FindRoom), new { id = room.rId }, room);
        }
        [HttpPut]
        public async Task<ActionResult<List<Room>>> UpdateRoom(int id, Room room)
        {
            Room ex = context.Rooms.Find(id) ?? throw new Exception("Room not found");
            ex.RoomName = room.RoomName;
            ex.RoomLoc = room.RoomLoc;
            await context.SaveChangesAsync();
            return await context.Rooms.ToListAsync();
        }
        [HttpDelete]
        public async Task<ActionResult<List<Room>>> DeleteRoom(int id)
        {
            Room ex = context.Rooms.Find(id) ?? throw new Exception("Room not found");
            context.Rooms.Remove(ex);
            await context.SaveChangesAsync();
            return await context.Rooms.ToListAsync();
        }
    }
}
