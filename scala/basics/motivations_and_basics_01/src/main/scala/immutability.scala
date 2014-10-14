
// object - a singleton basically
object ImmutabilityExample {

  def valsCannotBeReAssignedTo() {
    val name = "Reuben"
    // val name = "James" <-- does not compile
  }

  def caseClassesProvideImmutabilityConvenience() {
    val newGame = GameOfFifa(0, 0) // no "new" keyword required for case class
    val afterFirstGoal = newGame.copy(homeTeamScore = 1) // new instance of GameOfFifa
    val afterSecondGoal = newGame.copy(homeTeamScore = 2) // new instance of GameOfFifa

    // no side-effects in this code
    // a reference to any of the vals will *always* have the same value - easier for humans and computers to reason about
  }

  def immutableCollections() {
    // immutable collection - cannot update it
    val games = Seq(
      GameOfFifa(0, 0),
      GameOfFifa(1, 0),
      GameOfFifa(2, 0)
    )

    // can only create an updated copy of the collection
    val games2 = games :+ GameOfFifa(3, 0) // origin "games" completely unaffected by this
  }

  /* Be careful of this */
  def valsCanHoldMutableData() {
    // val will always point to same instance of game - but the state of the game can still change
    val mutableGame = new MutableGameOfFifa(0, 0)
    mutableGame.awayTeamScore = 1 // same instance being updated
    mutableGame.awayTeamScore = 2 // same instance being updated
  }

}

case class GameOfFifa(homeTeamScore: Int, awayTeamScore: Int)

class MutableGameOfFifa(var homeTeamScore: Int, var awayTeamScore: Int)
