using System;

[Serializable]
public class CharacterDataFormat
{
    int Level;
    int WeaponType;
    int Infamy;

    public CharacterDataFormat(int level, int weaponType, int infamy)
    {
        Level = level;
        WeaponType = weaponType;
        Infamy = infamy;
    }
}
