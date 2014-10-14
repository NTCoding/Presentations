
object Little_goodies {

  def stringInterpolations() = {
    val name = "Reuben's pet fish"
    println(s"My name is $name") // "s" string prefix and $ variable prefix
    println(s"My name is ${name.substring(0, 6)}") // use braces for expressions
  }

  def optionalDots() = {
    val name = "Reuben's handbag"
    name substring(0, 6) substring(0, 6)

    // equivalent to above
    name.substring(0, 6).substring(0, 6)
  }
}
