
using System.Net;
using AutoMapper;
using evenement.Data;
using evenement.Dto.Evenement;
using evenement.Dto.Message;
using evenement.ExceptionHandlerMidls.EventException;
using evenement.ExceptionHandlerMidls.UserException;
using evenement.Modals;
using evenement.Repository.IRepository;
using evenement.Utils;
using Microsoft.EntityFrameworkCore;

namespace evenement.Repository
{
    public class EvenementRepository : IEvenementRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public EvenementRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Evenement Create(CreateEvemenet create)
        {
            User? user = _context.Users.Where(or => or.Id == create.UserId).First();
            create.Organisateur = new Organisateur()
            {
                Name = user.Name,
                Email = user.Email,
                Username = user.Username,
                PasswordHash = user.PasswordHash,
                PasswordSalt = user.PasswordSalt
            };
            var type = _context.Types.Where(t => t.Id == create.TypeEvnId).First();
            var newEvet = _mapper.Map<CreateEvemenet, Evenement>(create);
            _context.Events.Add(newEvet);
            _context.SaveChanges();
            return newEvet;
        }

        public string Dalete(Guid Id)
        {
            Evenement? evenement = _context.Events
            .Include(ev => ev.Participants)
            .FirstOrDefault();
            if (evenement == null)
            {
                throw new EventNotFoundException(ErrorMessages.EventNotFoundException, (int)HttpStatusCode.NotFound);
            }
            _context.Events.Remove(evenement);
            _context.SaveChanges();
            return "ok";
        }

        public string EnvoieMessage(Guid idEvn, CreateMessageDto createmsg)
        {
            Evenement evenement = _context.Events.Where(v => v.id == idEvn).Include(p => p.Participants).FirstOrDefault();
            List<Participant> pa = evenement.Participants.Where(s => s.Status == "accepté").ToList();
            foreach (var item in pa)
            {
                if (item.UserId != null)
                {
                    // item.Messages.Add(_mapper.Map<CreateMessageDto, Message>(createmsg));
                    var newMessage = _mapper.Map<CreateMessageDto, Message>(createmsg);
                    newMessage.UserId = item.UserId;
                    _context.Messages.Add(newMessage);
                }
            }
            _context.SaveChanges();
            return "ok";
        }

        public IEnumerable<Evenement> GetAllEventByOrganisateur(Guid id)
        {

            throw new NotImplementedException();
        }

        public Evenement GetById(Guid Id)
        {
            Evenement? evenement = _context.Events.Where(e => e.id == Id).Include(p => p.Participants).FirstOrDefault();
            if (evenement is null)
            {
                throw new EventNotFoundException(ErrorMessages.EventNotFoundException, (int)HttpStatusCode.NotFound);
            }
            return evenement;
        }

        public IEnumerable<Evenement> GetEvenements()
        {
            return _context.Events.Include(p => p.Participants);
        }


        public Evenement Inscription(IscriptionAUnEvenemntDto iscription)
        {
            Evenement? evenement = _context.Events
            .Where(ev => ev.id == iscription.EventId)
            .Include(ev => ev.Participants)
            .FirstOrDefault();
            if (evenement == null)
            {
                throw new EventNotFoundException(ErrorMessages.EventNotFoundException, (int)HttpStatusCode.NotFound);
            }
            User user = _context.Users.Where(or => or.Id == iscription.UserId).First();
            if (user == null)
            {
                throw new UserNotFoundException(ErrorMessages.UserNotFoundException, (int)HttpStatusCode.NotFound);
            }
            Participant? p = evenement!.Participants.Find(u => u.Email == user.Email);
            if (p != null)
            {
                throw new ParticipantAlreadyExistException(ErrorMessages.ParticipantAlreadyExistException, (int)HttpStatusCode.NotFound);
            }
            else
            {

                //int CountParticipant = evenement.Participants.Count();
                //int MaxCount = evenement.MaxParticipant - CountParticipant;
                //if (MaxCount != 0)
                // {
                Participant participants = new Participant()
                {
                    Name = user.Name,
                    Email = user.Email,
                    Username = user.Username,
                    PasswordHash = user.PasswordHash,
                    PasswordSalt = user.PasswordSalt,
                    UserId = user.Id
                };
                //int nbrNow = evenement.Participants.Count() + 1;
                evenement.Participants!.Add(participants);
                //evenement.NombreParticipantActuel = nbrNow;

                _context.Events.Update(evenement);
                _context.SaveChanges();
                // }

            }
            return evenement;
        }

        public Evenement Update(Guid Id, UpdateEvenement update)
        {
            Evenement? evenement = _context.Events.Where(e => e.id == Id).Include(p => p.Participants).FirstOrDefault();
            if (evenement is null)
            {
                throw new EventNotFoundException(ErrorMessages.EventNotFoundException, (int)HttpStatusCode.NotFound);
            }
            evenement.Name = update.Name;
            evenement.Lieu = update.Lieu;
            evenement.DateDebut = update.DateDebut;
            evenement.MaxParticipant = update.MaxParticipant;
            evenement.Regle = update.Regle;

            _context.Events.Update(evenement);
            _context.SaveChanges();

            CreateMessageDto createmsg = new CreateMessageDto
            {
                Content = "Event details have been updated.",
                UserId = evenement.Participants
                 .Where(p => p.Status == "accepté" && p.UserId != null)
                 .Select(p => p.UserId)
                 .FirstOrDefault()
            };
            EnvoieMessage(Id, createmsg);
            return evenement;
        }

        public Evenement ValidatePArticipantofEvent(IscriptionAUnEvenemntDto iscription)
        {
            Evenement? evenement = _context.Events
            .Where(ev => ev.id == iscription.EventId)
            .Include(ev => ev.Participants)
            .FirstOrDefault();
            if (evenement == null)
            {
                throw new EventNotFoundException(ErrorMessages.EventNotFoundException, (int)HttpStatusCode.NotFound);
            }
            User user = _context.Users.Where(or => or.Id == iscription.UserId).First();
            if (user == null)
            {
                throw new UserNotFoundException(ErrorMessages.UserNotFoundException, (int)HttpStatusCode.NotFound);
            }
            Participant? p = evenement!.Participants.Find(u => u.Email == user.Email);
            int CountParticipant = evenement.Participants.Count();
            int MaxCount = evenement.MaxParticipant - CountParticipant;
            if (MaxCount != 0)
            {
                p.Status = "accepté";
                int nbrNow = evenement.Participants.Count();
                evenement.NombreParticipantActuel = nbrNow;
                _context.Events.Update(evenement);
                _context.SaveChanges();
            }


            return evenement;
        }
    }
}