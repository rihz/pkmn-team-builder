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
    hpIV = 31;
    hpEV = 0;
    atkIV = 31;
    atkEV = 0;
    defIV = 31;
    defEV = 0;
    spatkIV = 31;
    spatkEV = 0;
    spdefIV = 31;
    spdefEV = 0;
    speIV = 31;
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
    userId = 0;

    getEVSum(stat: string, value: number) {
        switch (stat.toLowerCase()) {
            case 'hp':
                return value + this.atkEV + this.defEV + this.spatkEV + this.spdefEV + this.speEV;
            case 'atk':
                return this.hpEV + value + this.defEV + this.spatkEV + this.spdefEV + this.speEV;
            case 'def':
                return this.hpEV + this.atkEV + value + this.spatkEV + this.spdefEV + this.speEV;
            case 'sp. atk':
                return this.hpEV + this.atkEV + this.defEV + value + this.spdefEV + this.speEV;
            case 'sp. def':
                return this.hpEV + this.atkEV + this.defEV + this.spatkEV + value + this.speEV;
            case 'spe':
                return this.hpEV + this.atkEV + this.defEV + this.spatkEV + this.spdefEV + value;
        }
    }
}

export class Move {
    id = 0;
    name = '';
    description = '';
    categoryId = 0;
    categoryName = '';
    pp = 0;
    power = 0;
    accuracy = 0;
    typeId = 0;
    typeName = '';
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

export class Team {
    id = 0;
    name = '';
    description = '';
    likes = 0;
    code = '';
    members: TeamMember[] = [];
    lastModified: Date = new Date();
}