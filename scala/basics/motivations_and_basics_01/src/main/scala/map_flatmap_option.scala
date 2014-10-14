
class map_flatmap_option {

  def optionMayOrMayNotHaveAValue() {
    val notAGameOfFifa: Option[GameOfFifa] = None
    val isAGameOfFifa: Option[GameOfFifa] = Some(GameOfFifa(1, 0))
  }

  def avoidingNullCheckingWithMap() {
    val mightBeAGameOfFifa: Option[GameOfFifa] = None

    // this the lambda will only execute if the value is Some[GameOfFifa] It will ignore it if the value is None
    // this is better than null checking all over your code
    mightBeAGameOfFifa.map { game =>
      println(game)
    }
  }

  def transformingCollectionsWithMap() {
    val games = Seq(
      GameOfFifa(5, 0),
      GameOfFifa(6, 0),
      GameOfFifa(7, 0),
      GameOfFifa(8, 0)
    )

    val with1AddedToEachGame = games.map(game => game.copy(homeTeamScore = game.homeTeamScore + 1))
  }

}
