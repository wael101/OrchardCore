using OrchardCore.ResourceManagement;

namespace OrchardCore.Resources
{
    public class ResourceManifest : IResourceManifestProvider
    {
        public void BuildManifests(IResourceManifestBuilder builder)
        {
            var manifest = builder.Add();

            manifest
                .DefineScript("jQuery")
                .SetUrl("~/OrchardCore.Resources/Scripts/jquery.min.js", "~/OrchardCore.Resources/Scripts/jquery.js")
                .SetCdn("https://code.jquery.com/jquery-3.3.1.min.js", "https://code.jquery.com/jquery-3.3.1.js")
                .SetCdnIntegrity("sha256-FgpCb/KJQlLNfOu91ta32o/NMZxltwRo8QtmkMRdAu8=", "sha256-2Kok7MbOyxpgUVvAk/HJ2jigOSYS2auK4Pfzbm7uH60=")
                .SetVersion("3.3.1");

            manifest
                .DefineScript("jQuery.slim")
                .SetUrl("~/OrchardCore.Resources/Scripts/jquery.slim.min.js", "~/OrchardCore.Resources/Scripts/jquery.slim.js")
                .SetCdn("https://code.jquery.com/jquery-3.3.1.slim.min.js", "https://code.jquery.com/jquery-3.3.1.slim.js")
                .SetCdnIntegrity("sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo", "sha384-sh6iinGECmk2oNezd0GDVuXqoHrZzF3PTML2nyt/lC61v2p1W7hGll/JkRFCOcMf")
                .SetVersion("3.3.1");

            manifest
                .DefineScript("jQuery-ui")
                .SetDependencies("jQuery")
                .SetUrl("~/OrchardCore.Resources/Scripts/jquery-ui.min.js", "~/OrchardCore.Resources/Scripts/jquery-ui.js")
                .SetCdn("https://code.jquery.com/ui/1.12.1/jquery-ui.min.js", "https://code.jquery.com/ui/1.12.1/jquery-ui.js")
                .SetCdnIntegrity("sha384-Dziy8F2VlJQLMShA6FHWNul/veM9bCkRUaLqr199K94ntO5QUrLJBEbYegdSkkqX", "sha384-JPbtLYL10d/Z1crlc6GGGGM3PavCzzoUJ1UxH0bXHOfguWHQ6XAWrIzW+MBGGXe5")
                .SetVersion("1.12.1");

            manifest
                .DefineStyle("jQuery-ui")
                .SetUrl("~/OrchardCore.Resources/Styles/jquery-ui.min.css", "~/OrchardCore.Resources/Styles/jquery-ui.css")
                .SetCdn("https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.min.css", "https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css")
                .SetCdnIntegrity("sha384-kcAOn9fN4XSd+TGsNu2OQKSuV5ngOwt7tg73O4EpaD91QXvrfgvf0MR7/2dUjoI6", "sha384-xewr6kSkq3dBbEtB6Z/3oFZmknWn7nHqhLVLrYgzEFRbU/DHSxW7K3B44yWUN60D")
                .SetVersion("1.12.1");

            manifest
                .DefineScript("jQuery-ui-i18n")
                .SetDependencies("jQuery-ui")
                .SetUrl("~/OrchardCore.Resources/Scripts/jquery-ui-i18n.min.js", "~/OrchardCore.Resources/Scripts/jquery-ui-i18n.js")
                .SetCdn("https://ajax.googleapis.com/ajax/libs/jqueryui/1.7.2/i18n/jquery-ui-i18n.min.js", "https://ajax.googleapis.com/ajax/libs/jqueryui/1.7.2/i18n/jquery-ui-i18n.js")
                .SetCdnIntegrity("sha384-0rV7y4NH7acVmq+7Y9GM6evymvReojk9li+7BYb/ug61uqPSsXJ4uIScVY+N9qtd", "sha384-EEQKK6fEtofGTgGugeA6uehhNCEM1w2nYp1rgUGV9lU4wRFjekt9mPFH3ZplAw2Y")
                .SetVersion("1.7.2");

            manifest
                .DefineScript("bootstrap")
                .SetDependencies("jQuery")
                .SetCdn("https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js", "https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.js")
                .SetCdnIntegrity("sha384-vhJnz1OVIdLktyixHY4Uk3OHEwdQqPppqYR8+5mjsauETgLOcEynD9oPHhhz18Nw", "sha384-it0Suwx+VjMafDIVf5t+ozEbrflmNjEddSX5LstI/Xdw3nv4qP/a4e8K4k5hH6l4")
                .SetVersion("3.4.0");

            manifest
                .DefineStyle("bootstrap")
                .SetCdn("https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css", "https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.css")
                .SetCdnIntegrity("sha384-PmY9l28YgO4JwMKbTvgaS7XNZJ30MK9FAZjjzXtlqyZCqBY6X6bXIkM++IkyinN+", "sha384-/5bQ8UYbZnrNY3Mfy6zo9QLgIQD/0CximLKk733r8/pQnXn2mgvhvKhcy43gZtJV")
                .SetVersion("3.4.0");

            manifest
                .DefineStyle("bootstrap-theme")
                .SetCdn("https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap-theme.min.css", "https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap-theme.css")
                .SetCdnIntegrity("sha384-jzngWsPS6op3fgRCDTESqrEJwRKck+CILhJVO5VvaAZCq8JYf8HsR/HPpBOOPZfR", "sha384-RtiWe5OsslAYZ9AVyorBziI2VQL7E27rzWygBJh7wrZuVPyK5jeQLLytnJIpJqfD")
                .SetVersion("3.4.0");

            manifest
                .DefineScript("popper")
                .SetUrl("~/OrchardCore.Resources/Scripts/popper.min.js", "~/OrchardCore.Resources/Scripts/popper.js")
                .SetCdn("https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js", "https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.js")
                .SetCdnIntegrity("sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1", "sha384-+pJF094Ta2RnahQyTGMfUIP/QGRrcV9M7UybKYko0JCH3B5ukTC6V0kEUSWTWhrn")
                .SetVersion("1.14.7");

            manifest
                .DefineScript("bootstrap")
                .SetDependencies("jQuery", "popper")
                .SetUrl("~/OrchardCore.Resources/Scripts/bootstrap.min.js", "~/OrchardCore.Resources/Scripts/bootstrap.js")
                .SetCdn("https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js", "https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.js")
                .SetCdnIntegrity("sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM", "sha384-rkSGcquOAzh5YMplX4tcXMuXXwmdF/9eRLkw/gNZG+1zYutPej7fxyVLiOgfoDgi")
                .SetVersion("4.3.1");

            manifest
                .DefineScript("bootstrap-bundle")
                .SetDependencies("jQuery")
                .SetUrl("~/OrchardCore.Resources/Scripts/bootstrap.bundle.min.js", "~/OrchardCore.Resources/Scripts/bootstrap.bundle.js")
                .SetCdn("https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.bundle.min.js", "https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.bundle.js")
                .SetCdnIntegrity("sha384-xrRywqdh3PHs8keKZN+8zzc5TX0GRTLCcmivcbNJWm2rs5C8PRhcEn3czEjhAO9o", "sha384-szbKYgPl66wivXHlSpJF+CKDAVckMVnlGrP25Sndhe+PwOBcXV9LlFh4MUpRhjIB")
                .SetVersion("4.3.1");

            manifest
                .DefineStyle("bootstrap")
                .SetUrl("~/OrchardCore.Resources/Styles/bootstrap.min.css", "~/OrchardCore.Resources/Styles/bootstrap.css")
                .SetCdn("https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css", "https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.css")
                .SetCdnIntegrity("sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T", "sha384-t4IGnnWtvYimgcRMiXD2ZD04g28Is9vYsVaHo5LcWWJkoQGmMwGg+QS0mYlhbVv3")
                .SetVersion("4.3.1");

            manifest
                .DefineScript("codemirror")
                .SetUrl("~/OrchardCore.Resources/Scripts/codemirror/codemirror.min.js", "~/OrchardCore.Resources/Scripts/codemirror/codemirror.js")
                .SetCdn("https://cdnjs.cloudflare.com/ajax/libs/codemirror/5.42.0/codemirror.min.js", "https://cdnjs.cloudflare.com/ajax/libs/codemirror/5.42.0/codemirror.js")
                .SetCdnIntegrity("sha384-1WlqTuBkhlft5hld74c3aAcO43Mp2uFKAl/z/6tYuEF0kDEnQRWnSIExi+EApxkW", "sha384-x1QKAzaJ+REY7xvp6SmcWnnyQdLJJaudAcV2KGSzDytetEOxiaYyaZ5PFLzBuvwR")
                .SetVersion("5.42.0");

            manifest
                .DefineScript("codemirror-addon-display-autorefresh")
                .SetUrl("~/OrchardCore.Resources/Scripts/codemirror/addon/display/autorefresh.min.js", "~/OrchardCore.Resources/Scripts/codemirror/addon/display/autorefresh.js")
                .SetCdn("https://cdnjs.cloudflare.com/ajax/libs/codemirror/5.42.0/addon/display/autorefresh.min.js", "https://cdnjs.cloudflare.com/ajax/libs/codemirror/5.42.0/addon/display/autorefresh.js")
                .SetCdnIntegrity("sha384-RJTX2U27s6bG/uQqwUnSXT4c8lTmHkfEbmb9d6KRrNW1qJuPdJs6r9SGFcPhRrYh", "sha384-5wrQkkCzj5dJInF+DDDYjE1itTGaIxO+TL6gMZ2eZBo9OyWLczkjolFX8kixX/9X")
                .SetVersion("5.42.0");

            manifest
                .DefineScript("codemirror-addon-mode-multiplex")
                .SetUrl("~/OrchardCore.Resources/Scripts/codemirror/addon/mode/multiplex.min.js", "~/OrchardCore.Resources/Scripts/codemirror/addon/mode/multiplex.js")
                .SetCdn("https://cdnjs.cloudflare.com/ajax/libs/codemirror/5.42.0/addon/mode/multiplex.min.js", "https://cdnjs.cloudflare.com/ajax/libs/codemirror/5.42.0/addon/mode/multiplex.js")
                .SetCdnIntegrity("sha384-5hVMruka72NXmFobYoE3ORYWcUc4wOh3fXfboJ3JjnBR8mhU94TrsoJ0bH2mPBEV", "sha384-tevfdBRzMxaUn5LZDUoDVAR24aItzKRH9ufnEuzu9VcIXDr6SEfU7bem2iCpfQ/Y")
                .SetVersion("5.42.0");

            manifest
                .DefineScript("codemirror-addon-mode-simple")
                .SetUrl("~/OrchardCore.Resources/Scripts/codemirror/addon/mode/simple.min.js", "~/OrchardCore.Resources/Scripts/codemirror/addon/mode/simple.js")
                .SetCdn("https://cdnjs.cloudflare.com/ajax/libs/codemirror/5.42.0/addon/mode/simple.min.js", "https://cdnjs.cloudflare.com/ajax/libs/codemirror/5.42.0/addon/mode/simple.js")
                .SetCdnIntegrity("sha384-CbSz/CPF0sQaPi+ZKRa9G1Bs4b06Byb6m0tH7Z4KCZNLUFEYXPpmEK0Mz59P+62i", "sha384-ntjFEzI50GYBTbLGaOVgBt97cxp74jfCqMDmZYlGWk8ZZp2leFMJYOp85T3tOeG9")
                .SetVersion("5.42.0");

            manifest
                .DefineScript("codemirror-mode-javascript")
                .SetUrl("~/OrchardCore.Resources/Scripts/codemirror/mode/javascript/javascript.min.js", "~/OrchardCore.Resources/Scripts/codemirror/mode/javascript/javascript.js")
                .SetCdn("https://cdnjs.cloudflare.com/ajax/libs/codemirror/5.42.0/mode/javascript/javascript.min.js", "https://cdnjs.cloudflare.com/ajax/libs/codemirror/5.42.0/mode/javascript/javascript.js")
                .SetCdnIntegrity("sha384-qkQBR4SvYVYypOG0YovM6ESyHGdIxVnNVzTjxlosL2G6a1k5l7PQq5Es6UcK7s28", "sha384-enNKmlcXaN/m72b+eJp7imTZv4QSaCnJU3ifoDddzaeaOzN+BEuTgdS+HluPzk7y")
                .SetVersion("5.42.0");

            manifest
                .DefineScript("codemirror-mode-sql")
                .SetUrl("~/OrchardCore.Resources/Scripts/codemirror/mode/sql/sql.min.js", "~/OrchardCore.Resources/Scripts/codemirror/mode/sql/sql.js")
                .SetCdn("https://cdnjs.cloudflare.com/ajax/libs/codemirror/5.42.0/mode/sql/sql.min.js", "https://cdnjs.cloudflare.com/ajax/libs/codemirror/5.42.0/mode/sql/sql.js")
                .SetCdnIntegrity("sha384-ujhASHKo2gNRZSQ/Q9V4fJkRekMw4o6rP46KxNrfRBGkiLUrkt7edeQzKcptitlP", "sha384-DNKIo1GnJyP28fs1kgoEHgWTmVSgAwJUKiAfEzIDDZeCbmbHPyM+pSFTOZrFHsKa")
                .SetVersion("5.42.0");

            manifest
                .DefineScript("codemirror-mode-xml")
                .SetUrl("~/OrchardCore.Resources/Scripts/codemirror/mode/xml/xml.min.js", "~/OrchardCore.Resources/Scripts/codemirror/mode/xml/xml.js")
                .SetCdn("https://cdnjs.cloudflare.com/ajax/libs/codemirror/5.42.0/mode/xml/xml.min.js", "https://cdnjs.cloudflare.com/ajax/libs/codemirror/5.42.0/mode/xml/xml.js")
                .SetCdnIntegrity("sha384-b6ENctnjsA8765OrHJ99pTSFwslh472P/F1dkCwgwHoS5vt0GnCjg2GVCOMAM/nO", "sha384-Fwj4mOSYqdnz4tUEeELhXbwTJWq+aGpRvHnE7XNaUquMFhMkj8UFX5rvNQD2zHlQ")
                .SetVersion("5.42.0");

            manifest
                .DefineStyle("codemirror")
                .SetUrl("~/OrchardCore.Resources/Scripts/codemirror/codemirror.min.css", "~/OrchardCore.Resources/Scripts/codemirror/codemirror.css")
                .SetCdn("https://cdnjs.cloudflare.com/ajax/libs/codemirror/5.42.0/codemirror.min.css", "https://cdnjs.cloudflare.com/ajax/libs/codemirror/5.42.0/codemirror.css")
                .SetCdnIntegrity("sha384-T6md2jYuokZmxpt4u/OxutZZs2NFnA/5oVdjrDkapBl/HHH3NfxhUMbFxEv5NTlh", "sha384-rTt9i9SnVCkukyC4WSJmDVMachnmXt3NchukWtR1miRFWpcgnyeOFxq2FBzsKltl")
                .SetVersion("5.42.0");

            manifest
                .DefineStyle("font-awesome")
                .SetUrl("~/OrchardCore.Resources/Styles/font-awesome.min.css", "~/OrchardCore.Resources/Styles/font-awesome.css")
                .SetCdn("https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css", "https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.css")
                .SetCdnIntegrity("sha384-wvfXpqpZZVQGK6TAh5PVlGOfQNHSoD2xbE+QkPxCAFlNEevoEH3Sl0sibVcOQVnN", "sha384-FckWOBo7yuyMS7In0aXZ0aoVvnInlnFMwCv77x9sZpFgOonQgnBj1uLwenWVtsEj")
                .SetVersion("4.7.0");

            manifest
                .DefineStyle("font-awesome")
                .SetCdn("https://cdn.jsdelivr.net/npm/@fortawesome/fontawesome-free@5.7.2/css/all.min.css", "https://cdn.jsdelivr.net/npm/@fortawesome/fontawesome-free@5.7.2/css/all.css")
                .SetCdnIntegrity("sha256-nAmazAk6vS34Xqo0BSrTb+abbtFlgsFK7NKSi6o7Y78=", "sha256-DVK12s61Wqwmj3XI0zZ9MFFmnNH8puF/eRHTB4ftKwk=")
                .SetVersion("5.7.2");

            manifest
                .DefineScript("font-awesome")
                .SetCdn("https://cdn.jsdelivr.net/npm/@fortawesome/fontawesome-free@5.7.2/js/all.min.js", "https://cdn.jsdelivr.net/npm/@fortawesome/fontawesome-free@5.7.2/js/all.js")
                .SetCdnIntegrity("sha256-Oq0ot7xtAl3WqR2277bwtP+iuV2uOTCh03M1ZCjIsJw=", "sha256-3thD9grC33Xa/xFJXfs8ZryCIwIn+LTX/k3r3KxSel0=")
                .SetVersion("5.7.2");

            manifest
                .DefineScript("font-awesome-v4-shims")
                .SetCdn("https://cdn.jsdelivr.net/npm/@fortawesome/fontawesome-free@5.7.2/js/v4-shims.min.js", "https://cdn.jsdelivr.net/npm/@fortawesome/fontawesome-free@5.7.2/js/v4-shims.js")
                .SetCdnIntegrity("sha256-Dy8KjLriNkSRrlgRJaVAoXdvxOlz8ico4RVRmZJsxD8=", "sha256-Hr8WbqmgdrcXJGhodaZ1ATNeusCHFbb3GxGVyA32C9E=")
                .SetVersion("5.7.2");
        }
    }
}
