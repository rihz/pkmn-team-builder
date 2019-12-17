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
    name = '';
    number = 0;
    icon = '';
    baseHP = 0;
    baseAtk = 0;
    baseDef = 0;
    baseSpAtk = 0;
    baseSpDef = 0;
    baseSpe = 0;
    image = '';
    shiny = '';
    type1Id = 0;
    type1Name = '';
    type2Id = 0;
    type2Name = '';
    moves: Move[] = [];
    abilities: Ability[] = [];
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
    spatkIV = 0;
    spatkEV = 0;
    spdefIV = 0;
    spdefEV = 0;
    speIV = 0;
    speEV = 0;
    nickname = '';
    pokemon: Pokemon;
    ability: Ability;
    nature: Nature;
    item: Item;
    move1: Move;
    move2: Move;
    move3: Move;
    move4: Move;
}

export class Move {
    id = 0;
    name = '';
    description = '';
    categoryId = 0;
    categoryName = '';
}

export class Ability {
    id = 0;
    name = '';
    description = '';
}

export class Item {
    id = 0;
    name = '';
    description = '';
    icon = '';
}

export class Nature {
    id = 0;
    name = '';
    increase = '';
    decrease = '';
}