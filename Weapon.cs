public class Weapon
{
    private int _damage;
    private int _bullets;

    public Weapon(int damage, int initialBullets)
    {
        _damage = damage;
        _bullets = initialBullets >= 0 ? initialBullets : 0;
    }

    public void Fire(Player player)
    {
        player.ApplyDamage(_damage);
        _bullets--;
    }
}

public class Player
{
    private int _health;

    public Player(int initialHealth)
    {
        _health = initialHealth > 0 ? initialHealth : 0;
    }

    public int MaxHealth => _health;
    public bool IsAlive => _health > 0;

    public void ApplyDamage(int damage)
    {
        if (damage < 0) return;

        _health = Math.Max(_health - damage, 0);
    }
}

public class Bot
{
    private Weapon _weapon;

    public Bot(Weapon weapon)
    {
        _weapon = weapon;
    }

    public void OnSeePlayer(Player player)
    {
        if (player.IsAlive)
        {
            _weapon.Fire(player);
        }
    }
}