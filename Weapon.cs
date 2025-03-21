public class Weapon
{
    private int _damage;
    private int _bullets;

    public Weapon(int damage, int initialBullets)
    {
        if (damage <= 0)
            throw new ArgumentException($"Урон не должен быть отрицательным. {damage.ToString()} = {damage}");

        if (initialBullets < 0)
            throw new ArgumentException($"Количество пуль не может быть отрицательным.{initialBullets.ToString()} = {initialBullets}");

        _damage = damage;
        _bullets = initialBullets;
    }

    public void Fire(Player player)
    {
        if (_bullets <= 0)
            throw new InvalidOperationException($"Патронов не осталось.{_bullets.ToString()} = {_bullets}");

        if (player == null)
            throw new ArgumentNullException(nameof(player), "Имеет значение null.");

        player.ApplyDamage(_damage);
        _bullets--;
    }
}

public class Player
{
    private int _health;

    public int MaxHealth => _health;
    public bool IsAlive => _health > 0;

    public Player(int health)
    {
        if (health <= 0)
            throw new ArgumentException($"Здоровье не должно быть отрицательным. {health.ToString()} = {health}");

        _health = health;
    }

    public void ApplyDamage(int damage)
    {
        if (damage < 0)
            throw new ArgumentException($"Урон не может быть отрицательным. {damage.ToString()} = {damage}");

        _health = Math.Max(_health - damage, 0);
    }
}

public class Bot
{
    private readonly Weapon _weapon;

    public Bot(Weapon weapon)
    {
        _weapon = weapon ?? throw new ArgumentNullException(nameof(weapon), "Имеет значение null.");
    }

    public void OnSeePlayer(Player player)
    {
        if (player == null)
            throw new ArgumentNullException(nameof(player), "Имеет значение null.");

        if (player.IsAlive)
        {
            _weapon.Fire(player);
        }
    }
}
