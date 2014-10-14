
object Lambdas {

  val games = Seq(
    GameOfFifa(1, 0),
    GameOfFifa(2, 1),
    GameOfFifa(1, 5),
    GameOfFifa(3, 3),
    GameOfFifa(2, 2)
  )

  def simplifyOperationsOnCollections() {
    // underscore for conciseness
    val gamesWithMoreThan1AwayGoal = games.filter(_.awayTeamScore > 1)

    // full syntax - equivalent to the above
    val gamesWithMoreThan1AwayGoal2 = games.filter(x => x.awayTeamScore > 1)
  }

  def richSetOfFunctionalOperationsOnCollections() {
    // find 1 or 0 matching items
    games.find(_.awayTeamScore == 3)

    // do any matching items exist
    games.exists(_.awayTeamScore == 5)

    // sort the collection
    games.sortBy(_.awayTeamScore)
  }
}
