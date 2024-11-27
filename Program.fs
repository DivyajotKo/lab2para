


// Define Records
type Coach = {
    Name: string
    FormerPlayer: bool
}

type Stats = {
    Wins: int
    Losses: int
}

type Team = {
    Name: string
    Coach: Coach
    Stats: Stats
}

// Create Coaches, Stats, and Teams
let coach1 = { Name = "Chahat"; FormerPlayer = true }
let coach2 = { Name = "Anisha"; FormerPlayer = false }
let coach3 = { Name = "Rishit"; FormerPlayer = false }
let coach4 = { Name = "Shail"; FormerPlayer = true }
let coach5 = { Name = "Roban"; FormerPlayer = false }

let team1Stats = { Wins = 50; Losses = 20 }
let team2Stats = { Wins = 45; Losses = 25 }
let team3Stats = { Wins = 55; Losses = 10 }
let team4Stats = { Wins = 40; Losses = 30 }
let team5Stats = { Wins = 35; Losses = 45 }

let team1 = { Name = "Golden State Warriors"; Coach = coach1; Stats = team1Stats }
let team2 = { Name = "Miami Heat"; Coach = coach2; Stats = team2Stats }
let team3 = { Name = "San Antonio Spurs"; Coach = coach3; Stats = team3Stats }
let team4 = { Name = "Philadelphia 76ers"; Coach = coach4; Stats = team4Stats }
let team5 = { Name = "Toronto Raptors"; Coach = coach5; Stats = team5Stats }

// Create a List of Teams
let teams = [team1; team2; team3; team4; team5]

// Filter Successful Teams (Wins > Losses)
let successfulTeams = 
    teams 
    |> List.filter (fun team -> team.Stats.Wins > team.Stats.Losses)

// Map to Calculate Success Percentages
let teamSuccessPercentages = 
    teams 
    |> List.map (fun team -> 
        let winRate = (float team.Stats.Wins) / (float (team.Stats.Wins + team.Stats.Losses)) * 100.0
        (team.Name, winRate))

printfn "Successful Teams: %A" successfulTeams
printfn "Team Success Percentages: %A" teamSuccessPercentages


// Define Discriminated Unions
type Cuisine = 
    | Korean
    | Turkish

type MovieType = 
    | Regular
    | IMAX
    | DBOX
    | RegularWithSnacks
    | IMAXWithSnacks
    | DBOXWithSnacks

type Activity = 
    | BoardGame
    | Chill
    | Movie of MovieType
    | Restaurant of Cuisine
    | LongDrive of int * float

// Function to Calculate Budget
let calculateBudget activity = 
    match activity with
    | BoardGame -> 0.0
    | Chill -> 0.0
    | Movie movieType -> 
        match movieType with
        | Regular -> 12.0
        | IMAX -> 17.0
        | DBOX -> 20.0
        | RegularWithSnacks -> 12.0 + 5.0
        | IMAXWithSnacks -> 17.0 + 5.0
        | DBOXWithSnacks -> 20.0 + 5.0
    | Restaurant cuisine -> 
        match cuisine with
        | Korean -> 70.0
        | Turkish -> 65.0
    | LongDrive (distance, fuelRate) -> 
        float distance * fuelRate

// Test the Budget Calculation
let activities = [
    BoardGame
    Chill
    Movie Regular
    Movie IMAXWithSnacks
    Restaurant Korean
    LongDrive (100, 1.5)
]

let budgets = 
    activities 
    |> List.map (fun activity -> (activity, calculateBudget activity))

printfn "Activity Budgets: %A" budgets