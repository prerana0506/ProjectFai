using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectFai.Models;

namespace ProjectFai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingController : ControllerBase
    {
        private readonly MDbContext context;
        public MeetingController(MDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Meetingss>>> AllMeetingss()
        {
            return await context.meetingsses.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Meetingss>> FindMeeting(int id)
        {
            return await context.meetingsses.FindAsync(id) ?? throw new Exception("Meeting not found");
        }

        [HttpPost]
        public async Task<ActionResult<Meetingss>> AddMeeting(Meetingss meeting)
        {
            context.meetingsses.Add(meeting);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(FindMeeting), new { id = meeting.mId }, meeting);
        }
        [HttpPut]
        public async Task<ActionResult<List<Meetingss>>> UpdateMeeting(int id, Meetingss meeting)
        {
            Meetingss ex = context.meetingsses.Find(id) ?? throw new Exception("Meeting not found");
            ex.mDetails = meeting.mDetails;
            ex.mDate = meeting.mDate;
            ex.startTime = meeting.startTime;
            ex.endTime = meeting.endTime;
            ex.campusLoc = meeting.campusLoc;
            await context.SaveChangesAsync();
            return await context.meetingsses.ToListAsync();
        }
        [HttpDelete]
        public async Task<ActionResult<List<Meetingss>>> DeleteMeeting(int id)
        {
            Meetingss ex = context.meetingsses.Find(id) ?? throw new Exception("Meeting not found");
            context.meetingsses.Remove(ex);
            await context.SaveChangesAsync();
            return await context.meetingsses.ToListAsync();
        }
    }
}
