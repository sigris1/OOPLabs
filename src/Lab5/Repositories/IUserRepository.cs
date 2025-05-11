using Users;

namespace UserRepository;

public interface IUserRepository
{
    Task<IUser?> FindUserByUserId(long userid);
}