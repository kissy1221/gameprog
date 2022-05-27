require 'dxopal'
include DXOpal
Window.load_resources do
  Window.bgcolor = C_CYAN

  Window.loop do
    Window.draw_font(0, 0, "HelloWorld!_visualProgramming", Font.default, color: C_WHITE)
  end
end
