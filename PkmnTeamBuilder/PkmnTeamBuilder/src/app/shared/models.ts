export class UserRegistration {
    email: string;
    password: string;
}

export class Credentials {
    email: string;
    password: string;
}

export class Pokemon {
    id = 0;
    number = 0;
    name = '';
    description = '';
    abilities = [];
    moves = [];

}

export class TeamMember {
    id = 0;
    pokemonId = 0;
    abilityId = 0;
    natureId = 0;
    move1Id = 0;
    move2Id = 0;
    move3Id = 0;
    move4Id = 0;
    itemId = 0;
    isShiny = false;
    hpIV = 0;
    hpEV = 0;
    atkIV = 0;
    atkEV = 0;
    defIV = 0;
    defEV = 0;
    satkIV = 0;
    satkEV = 0;
    sdefIV = 0;
    sdefEV = 0;
    spdIV = 0;
    spdEV = 0;
}