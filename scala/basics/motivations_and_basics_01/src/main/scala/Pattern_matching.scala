
object Pattern_matching {

  def patternMatchingOnTypeOrStructure() {
    val mightBeAGameOfFifa: Option[GameOfFifa] = Some(GameOfFifa(1, 0))
    mightBeAGameOfFifa match {
      case Some(game) =>
        println(s"Variable contains a game of fifa")

      case None =>
        println(s"Variable does not contain a game of fifa")
    }
  }

  def patternMatchingOnValues() {
    GameOfFifa(1, 0) match {
      case GameOfFifa(1, 0) =>
        println("The score was 1 - 0")

      case GameOfFifa(0, 1) =>
        println("The score was 0 - 1")

      // underscore means catch everything else
      case _ =>
        println("The score was not 1 - 0 or 0 - 1")

    }
  }

  // many functions are cleaner than pattern matching. Pattern matching a lot is amateurish
  // see this brilliant blog post - http://tonymorris.github.io/blog/posts/scalaoption-cheat-sheet/
  def alternativesToPatternMatching() {
    val mightBeAGameOfFifa: Option[GameOfFifa] = Some(GameOfFifa(5, 1))

    mightBeAGameOfFifa.getOrElse(GameOfFifa(1, 0)) // get the value, or use the supplied value if it is "None"
    mightBeAGameOfFifa.orElse(Some(GameOfFifa(1, 0))) // get the value (without unwrapping),or use the supplied value
  }
}
