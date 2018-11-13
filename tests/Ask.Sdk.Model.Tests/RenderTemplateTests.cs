using Ask.Sdk.Model.Response.Directive;
using Ask.Sdk.Model.Response.Directive.Templates;
using Ask.Sdk.Model.Response.Directive.Templates.Types;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Ask.Sdk.Model.Tests
{
    public class RenderTemplateTests
    {
        private const string ExamplesPath = "Examples";
        private const string ImageSource = "https://example.com/resources/card-images/mount-saint-helen-small.png";
        private const string ImageDescription = "Mount St. Helens landscape";
        //Examples found at: https://developer.amazon.com/public/solutions/alexa/alexa-skills-kit/docs/display-interface-reference#configure-your-skill-for-the-display-directive

        [Fact]
        public void Creates_RenderTemplateDirective()
        {
            var actual = new RenderTemplateDirective
            {
                Template = new BodyTemplate1
                {
                    Token = "A2079",
                    BackButton = BackButtonBehavior.Visible,
                    BackgroundImage = new Image
                    {
                        ContentDescription = "Textured grey background",
                        Sources = new List<ImageInstance>
                        {
                            new ImageInstance { Url="https://www.example.com/background-image1.png"}
                        }
                    },
                    Title = "My Favorite Car",
                    Content = new TextContent
                    {
                        Primary = new TextField { Text = "See my favorite car", Type = TextType.Plain },
                        Secondary = new TextField { Text = "Custom-painted", Type = TextType.Plain },
                        Tertiary = new TextField { Text = "By me!", Type = TextType.Plain }
                    }
                }
            };
            Assert.True(Utility.CompareJson(actual, "RenderTemplateDirective.json"));
        }

        [Fact]
        public void Create_BodyTemplate1()
        {
            var actual = new BodyTemplate1
            {
                BackButton = BackButtonBehavior.Hidden,
                Content = new TextContent
                {
                    Primary = new TextField { Text = "See my favorite car", Type = TextType.Plain },
                    Secondary = new TextField { Text = "Custom-painted", Type = TextType.Plain },
                    Tertiary = new TextField { Text = "By me!", Type = TextType.Plain }
                }
            };
            Assert.True(Utility.CompareJson(actual, "TemplateBodyTemplate1.json"));
        }

        [Fact]
        public void Create_BodyTemplate2()
        {
            var actual = new BodyTemplate2
            {
                Token = "A2079",
                BackButton = BackButtonBehavior.Visible,
                Image = new Image
                {
                    ContentDescription = "My favorite car",
                    Sources = new List<ImageInstance>
                    {
                        new ImageInstance{Url="https://www.example.com/my-favorite-car.png"}
                    }
                },
                BackgroundImage = new Image
                {
                    ContentDescription = "Textured grey background",
                    Sources = new List<ImageInstance>
                    {
                        new ImageInstance { Url="https://www.example.com/background-image1.png"}
                    }
                },


                Title = "My Favorite Car",
                Content = new TextContent
                {
                    Primary = new TextField { Text = "See my favorite car", Type = TextType.Plain },
                    Secondary = new TextField { Text = "Custom-painted", Type = TextType.Plain },
                    Tertiary = new TextField { Text = "By me!", Type = TextType.Plain }
                }
            };
            Assert.True(Utility.CompareJson(actual, "TemplateBodyTemplate2.json"));
        }

        [Fact]
        public void Create_BodyTemplate6()
        {
            var actual = new BodyTemplate6
            {
                Token = "SampleTemplate_3476",
                BackButton = BackButtonBehavior.Visible,
                Image = new Image
                {
                    ContentDescription = ImageDescription,
                    Sources = new List<ImageInstance> { new ImageInstance { Url = ImageSource } }
                },
                BackgroundImage = new Image
                {
                    ContentDescription = "Textured grey background",
                    Sources = new List<ImageInstance>
                    {
                        new ImageInstance { Url="https://www.example.com/background-image1.png"}
                    }
                },


                Title = "Sample BodyTemplate6",
                Content = new TextContent
                {
                    Primary = new TextField { Text = "See my favorite car", Type = TextType.Plain },
                    Secondary = new TextField { Text = "Custom-painted", Type = TextType.Plain },
                    Tertiary = new TextField { Text = "By me!", Type = TextType.Plain }
                }
            };
            Assert.True(Utility.CompareJson(actual, "TemplateBodyTemplate6.json"));
        }

        [Fact]
        public void Create_BodyTemplate7()
        {
            var actual = new BodyTemplate7
            {
                Token = "SampleTemplate_3476",
                BackButton = BackButtonBehavior.Visible,
                Image = new Image
                {
                    ContentDescription = ImageDescription,
                    Sources = new List<ImageInstance> { new ImageInstance { Url = ImageSource } }
                },
                BackgroundImage = new Image
                {
                    ContentDescription = "Textured grey background",
                    Sources = new List<ImageInstance>
                    {
                        new ImageInstance { Url="https://www.example.com/background-image1.png"}
                    }
                },


                Title = "Sample BodyTemplate7"
            };
            Assert.True(Utility.CompareJson(actual, "TemplateBodyTemplate7.json"));
        }

        [Fact]
        public void Create_ListTemplate1()
        {
            var actual = new ListTemplate1
            {
                Token = "list_template_one",
                Title = "Pizzas",
                Items = new List<ListItem>
                {
                    new ListItem
                    {
                        Token="item_1",
                        Content = new TextContent
                        {
                            Primary = new TextField
                            {
                                Text="<font size='7'>Supreme</font> <br/> Large Pan Pizza $17.00",
                                Type=TextType.Rich
                            },
                            Secondary = new TextField
                            {
                                Text="Secondary Text",
                                Type=TextType.Plain
                            },
                            Tertiary=new TextField
                            {
                                Text=string.Empty,
                                Type=TextType.Plain
                            }
                        },
                        Image = new Image
                        {
                            Sources = new List<ImageInstance>{new ImageInstance
                            {
                                Url= "http://www.example.com/images/thumb/SupremePizza1.jpg"
                            }},
                            ContentDescription = "Supreme Large Pan Pizza"
                        }
                    },
                    new ListItem
                    {
                        Token="item_2",
                        Content = new TextContent
                        {
                            Primary = new TextField
                            {
                                Text="<font size='7'>Meat Eater</font> <br/> Large Pan Pizza $19.00",
                                Type=TextType.Rich
                            }
                        },
                        Image = new Image
                        {
                            Sources = new List<ImageInstance>{new ImageInstance
                            {
                                Url= "http://www.example.com/images/thumb/MeatEaterPizza1.jpg"
                            }},
                            ContentDescription = "Meat Eater Large Pan Pizza"
                        }
                    },
                }
            };
            Assert.True(Utility.CompareJson(actual, "TemplateListTemplate1.json"));
        }

        [Fact]
        public void Create_ListTemplate2()
        {
            var actual = new ListTemplate2
            {
                Token = "A2079",
                Title = "My Favourite Pizzas",
                BackButton = BackButtonBehavior.Visible,
                BackgroundImage = new Image
                {
                    ContentDescription = "Textured grey background",
                    Sources = new List<ImageInstance>
                    {
                        new ImageInstance { Url="https://www.example.com/background-image1.png"}
                    }
                },
                Items = new List<ListItem>
                {
                    new ListItem
                    {
                        Token="item_1",
                        Content = new TextContent
                        {
                            Primary = new TextField
                            {
                                Text="<font size='7'>Supreme</font> <br/> Large Pan Pizza $17.00",
                                Type=TextType.Rich
                            },
                            Secondary = new TextField
                            {
                                Text="Secondary Text",
                                Type=TextType.Plain
                            },
                            Tertiary=new TextField
                            {
                                Text=string.Empty,
                                Type=TextType.Plain
                            }
                        },
                        Image = new Image
                        {
                            Sources = new List<ImageInstance>{new ImageInstance
                            {
                                Url= "http://www.example.com/images/thumb/SupremePizza1.jpg"
                            }},
                            ContentDescription = "Supreme Large Pan Pizza"
                        }
                    }
                }
            };
            Assert.True(Utility.CompareJson(actual, "TemplateListTemplate2.json"));
        }

        [Fact]
        public void Create_Basic_Image()
        {
            var actual = new Image
            {
                ContentDescription = ImageDescription,
                Sources = new List<ImageInstance> { new ImageInstance { Url = ImageSource } }
            };
            Assert.True(Utility.CompareJson(actual, "ImageBasic.json"));
        }

        [Fact]
        public void Create_Image()
        {
            var actual = new Image
            {
                ContentDescription = ImageDescription,
                Sources = new List<ImageInstance> { new ImageInstance {
                        Url = ImageSource,
                        Size = ImageSize.Small,
                        Height=480,
                        Width=640
                    }
                }
            };
            Assert.True(Utility.CompareJson(actual, "Image.json"));
        }
    }
}
